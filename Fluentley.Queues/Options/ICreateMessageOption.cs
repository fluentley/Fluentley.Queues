using System;
using System.Threading;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;

namespace Fluentley.Queues.Options
{
    public interface ICreateMessageOption<T>
    {
        ICreateMessageOption<T> Name(string value);
        ICreateMessageOption<T> ExpiresIn(TimeSpan value);
        ICreateMessageOption<T> ScheduleForExecutionOn(TimeSpan value);
        ICreateMessageOption<T> ScheduleOn(TimeSpan value);
        ICreateMessageOption<T> RequestOptions(Action<QueueRequestOptions> value);
        ICreateMessageOption<T> CancellationToken(CancellationToken value);
        ICreateMessageOption<T> OperationContext(Action<OperationContext> value);
        ICreateMessageOption<T> Message(T value);
    }
}