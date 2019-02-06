using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fluentley.Queues.Tests
{
    [TestClass]
    public class QueueServiceTest
    {
        private readonly QueueService _service;

        public QueueServiceTest()
        {
            _service = new QueueService("AccountName=devstoreaccount1;AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;DefaultEndpointsProtocol=http;BlobEndpoint=http://127.0.0.1:10000/devstoreaccount1;QueueEndpoint=http://127.0.0.1:10001/devstoreaccount1;TableEndpoint=http://127.0.0.1:10002/devstoreaccount1;");
        }

        [TestMethod]
        public async Task CreateQueueTest()
        {
            await _service.CreateMessage<string>(options => options
                .Name("TestQueue")
                .Message("Hello World"));
        }
    }
}