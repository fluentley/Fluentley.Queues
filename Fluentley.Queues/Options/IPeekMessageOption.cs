using System.Threading;

namespace Fluentley.Queues.Options
{
    public interface IPeekMessageOption
    {
        IPeekMessageOption Name(string value);
        IPeekMessageOption CancellationToken(CancellationToken value);
    }
}