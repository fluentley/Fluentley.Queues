using System;
using System.Threading;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;

namespace Fluentley.Queues.Options
{
    public interface IDeleteMessageOption
    {
        IDeleteMessageOption Name(string value);
        IDeleteMessageOption Ids(params string[] value);
        IDeleteMessageOption RequestOptions(Action<QueueRequestOptions> value);
        IDeleteMessageOption OperationContext(Action<OperationContext> value);
        IDeleteMessageOption CancellationToken(CancellationToken value);
    }
}