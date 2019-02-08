using System;
using System.Threading;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;

namespace Fluentley.Queues.Options
{
    internal class PeekMessageOption : IPeekMessageOption
    {
        public string QueueName { get; set; }
        public CancellationToken QueueCancellationToken { get; set; }
        public OperationContext QueueOperationContext { get; set; }
        public QueueRequestOptions QueueRequestOptions { get; set; }

        public IPeekMessageOption Name(string value)
        {
            QueueName = value.ToLower();
            return this;
        }

        public IPeekMessageOption CancellationToken(CancellationToken value)
        {
            QueueCancellationToken = value;
            return this;
        }

        public IPeekMessageOption RequestOptions(Action<QueueRequestOptions> value)
        {
            QueueRequestOptions = new QueueRequestOptions();
            value(QueueRequestOptions);

            return this;
        }

        public IPeekMessageOption OperationContext(Action<OperationContext> value)
        {
            QueueOperationContext = new OperationContext();
            value(QueueOperationContext);

            return this;
        }
    }
}