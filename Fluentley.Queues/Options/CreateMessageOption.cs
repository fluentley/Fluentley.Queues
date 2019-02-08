using System;
using System.Threading;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage.Queue.Protocol;

namespace Fluentley.Queues.Options
{
    internal class CreateMessageOption<T> : ICreateMessageOption<T>
    {
        public OperationContext QueueOperationContext { get; set; }
        public QueueRequestOptions QueueRequestOptions { get; set; }
        public TimeSpan? QueueScheduledOn { get; set; }
        public TimeSpan? QueueExpiresIn { get; set; }
        public string QueueName { get; set; }
        public CancellationToken QueueCancellationToken { get; set; }
        public T QueueMessage { get; set; }
        public QueuePermissions QueuePermissions { get; set; }

        public ICreateMessageOption<T> Name(string value)
        {
            QueueName = value.ToLower();
            return this;
        }

        public ICreateMessageOption<T> Message(T value)
        {
            QueueMessage = value;
            return this;
        }

        public ICreateMessageOption<T> ExpiresIn(TimeSpan value)
        {
            QueueExpiresIn = value;
            return this;
        }

        public ICreateMessageOption<T> ScheduleForExecutionOn(TimeSpan value)
        {
            QueueScheduledOn = value;
            return this;
        }

        public ICreateMessageOption<T> ScheduleOn(TimeSpan value)
        {
            QueueScheduledOn = value;
            return this;
        }

        public ICreateMessageOption<T> RequestOptions(Action<QueueRequestOptions> value)
        {
            QueueRequestOptions = new QueueRequestOptions();
            value(QueueRequestOptions);

            return this;
        }

        public ICreateMessageOption<T> CancellationToken(CancellationToken value)
        {
            QueueCancellationToken = value;
            return this;
        }

        public ICreateMessageOption<T> OperationContext(Action<OperationContext> value)
        {
            QueueOperationContext = new OperationContext();
            value(QueueOperationContext);

            return this;
        }

        public ICreateMessageOption<T> Permissions(Action<QueuePermissions> value)
        {
            QueuePermissions = new QueuePermissions();
            value(QueuePermissions);
            return this;
        }
    }
}