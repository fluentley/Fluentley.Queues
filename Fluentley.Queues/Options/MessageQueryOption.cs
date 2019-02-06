using System;
using System.Threading;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;

namespace Fluentley.Queues.Options
{
    internal class MessageQueryOption : IMessageQueryOption
    {
        public string QueueName { get; set; }

        public string[] QueueIds { get; set; }

        public CancellationToken QueueCancellationToken { get; set; }
        public OperationContext QueueOperationContext { get; set; }
        public QueueRequestOptions QueueRequestOptions { get; set; }

        public IMessageQueryOption Name(string value)
        {
            QueueName = value.ToLower();
            return this;
        }

        public IMessageQueryOption Ids(params string[] value)
        {
            QueueIds = value;
            return this;
        }

        public IMessageQueryOption RequestOptions(Action<QueueRequestOptions> value)
        {
            QueueRequestOptions = new QueueRequestOptions();
            value(QueueRequestOptions);

            return this;
        }

        public IMessageQueryOption RequestOptions(QueueRequestOptions value)
        {
            QueueRequestOptions = value;
            return this;
        }

        public IMessageQueryOption OperationContext(Action<OperationContext> value)
        {
            QueueOperationContext = new OperationContext();
            value(QueueOperationContext);

            return this;
        }

        public IMessageQueryOption OperationContext(OperationContext value)
        {
            QueueOperationContext = value;
            return this;
        }

        public IMessageQueryOption CancellationToken(CancellationToken value)
        {
            QueueCancellationToken = value;
            return this;
        }
    }
}