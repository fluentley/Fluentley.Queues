using System.Linq;
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
        public async Task QueueCrudTest()
        {
            var queueName = "TestQueue";

            await _service.CreateMessage<string>(options => options
                .Name(queueName)
                .Message("Hello World 2"));

            var messages = await _service.Messages(options => options
                .Name(queueName)
            );


            Assert.AreEqual(messages.Any(), true);


            await _service.DeleteMessage(options => options.Name(queueName).Ids(messages.First().Id));
        }
    }
}