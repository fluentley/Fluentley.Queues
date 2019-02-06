using System;
using System.Threading;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;

namespace Fluentley.Queues.Options
{
    public interface IMessageQueryOption
    {
        IMessageQueryOption Name(string value);
        IMessageQueryOption Ids(params string[] value);
        IMessageQueryOption RequestOptions(Action<QueueRequestOptions> value);
        IMessageQueryOption RequestOptions(QueueRequestOptions value);
        IMessageQueryOption OperationContext(Action<OperationContext> value);
        IMessageQueryOption OperationContext(OperationContext value);
        IMessageQueryOption CancellationToken(CancellationToken value);
    }
}