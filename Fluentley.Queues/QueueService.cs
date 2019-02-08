using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fluentley.Queues.Options;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Newtonsoft.Json;

namespace Fluentley.Queues
{
    public class QueueService
    {
        private readonly CloudQueueClient _client;

        public QueueService(string connectionString)
        {
            var storageAccount = CloudStorageAccount.Parse(connectionString);
            _client = storageAccount.CreateCloudQueueClient();
        }

        public async Task<CloudQueueMessage> CreateMessage<T>(Action<ICreateMessageOption<T>> options)
        {
            var queueOption = new CreateMessageOption<T>();
            options(queueOption);

            var queueClient = _client.GetQueueReference(queueOption.QueueName);

            await queueClient.CreateIfNotExistsAsync(queueOption.QueueRequestOptions, queueOption.QueueOperationContext, queueOption.QueueCancellationToken);

            var queueMessage = new CloudQueueMessage(JsonConvert.SerializeObject(queueOption.QueueMessage));

            await queueClient.AddMessageAsync(queueMessage, queueOption.QueueExpiresIn, queueOption.QueueScheduledOn, queueOption.QueueRequestOptions, queueOption.QueueOperationContext, queueOption.QueueCancellationToken);

            return queueMessage;
        }

        public async Task<CloudQueueMessage> PeekMessage(Action<IPeekMessageOption> options)
        {
            var queueOption = new PeekMessageOption();
            options(queueOption);

            var queueClient = _client.GetQueueReference(queueOption.QueueName);

            var isExists = await queueClient.ExistsAsync(queueOption.QueueRequestOptions, queueOption.QueueOperationContext, queueOption.QueueCancellationToken);

            if (!isExists)
                return null;

            return await queueClient.PeekMessageAsync(queueOption.QueueRequestOptions, queueOption.QueueOperationContext, queueOption.QueueCancellationToken);
        }

        public async Task DeleteMessage(Action<IDeleteMessageOption> options)
        {
            var queueOption = new DeleteMessageOption();
            options(queueOption);

            var queueClient = _client.GetQueueReference(queueOption.QueueName);

            var messages = await Messages(messageOptions => messageOptions
                .CancellationToken(queueOption.QueueCancellationToken)
                .Ids(queueOption?.QueueIds?.ToArray())
                .Name(queueOption.QueueName)
                .OperationContext(queueOption.QueueOperationContext)
                .RequestOptions(queueOption.QueueRequestOptions)
            );

            foreach (var message in messages) await queueClient.DeleteMessageAsync(message, queueOption.QueueRequestOptions, queueOption.QueueOperationContext, queueOption.QueueCancellationToken);
        }

        public async Task<IEnumerable<CloudQueueMessage>> Messages(Action<IMessageQueryOption> options)
        {
            var queueOption = new MessageQueryOption();
            options(queueOption);

            var queueClient = _client.GetQueueReference(queueOption.QueueName);

            var isExists = await queueClient.ExistsAsync();

            if (!isExists)
                return new List<CloudQueueMessage>();

            queueClient.FetchAttributes();

            var numberOfMessages = queueClient.ApproximateMessageCount ?? 0;
            if (numberOfMessages == 0)
                return new List<CloudQueueMessage>();

            var messages = await queueClient.GetMessagesAsync(numberOfMessages, queueOption.QueueCancellationToken);

            if (queueOption?.QueueIds?.Any() ?? false)
                messages = messages.Where(x => queueOption.QueueIds.Contains(x.Id));

            return messages;
        }
    }
}