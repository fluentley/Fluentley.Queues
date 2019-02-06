using System;
using System.Threading;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;

namespace Fluentley.Queues.Options
{
    internal class DeleteMessageOption : IDeleteMessageOption
    {
        public string QueueName { get; set; }

        public string[] QueueIds { get; set; }

        public CancellationToken QueueCancellationToken { get; set; }
        public OperationContext QueueOperationContext { get; set; }
        public QueueRequestOptions QueueRequestOptions { get; set; }

        public IDeleteMessageOption Name(string value)
        {
            QueueName = value.ToLower();
            return this;
        }

        public IDeleteMessageOption Ids(params string[] value)
        {
            QueueIds = value;
            return this;
        }

        public IDeleteMessageOption RequestOptions(Action<QueueRequestOptions> value)
        {
            QueueRequestOptions = new QueueRequestOptions();
            value(QueueRequestOptions);

            return this;
        }

        public IDeleteMessageOption OperationContext(Action<OperationContext> value)
        {
            QueueOperationContext = new OperationContext();
            value(QueueOperationContext);

            return this;
        }

        public IDeleteMessageOption CancellationToken(CancellationToken value)
        {
            QueueCancellationToken = value;
            return this;
        }
    }
}