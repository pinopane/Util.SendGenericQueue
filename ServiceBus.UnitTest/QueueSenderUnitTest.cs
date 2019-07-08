namespace ServiceBus.UnitTest
{
    using Microsoft.Azure.ServiceBus;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System.Threading.Tasks;
    using Utils.ServiceBus.ClassLibrary.Queue.Contracts;
    using Utils.ServiceBus.ClassLibrary.Queue.Services;

    [TestClass]
    public class QueueSenderUnitTest
    {
        private Mock<IQueueClient> _queueClientMock;
        private IAzureQueueSenderService<Helpers.Message> _azureQueueService;
        private AzureQueueSettingsService _azureQueueSettingsService;
        [TestInitialize]
        public void Initialize()
        {
            _queueClientMock = new Mock<IQueueClient>();
            _azureQueueSettingsService = new AzureQueueSettingsService("Endpoint=sb://thisConnectionStringNotExist.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=XqQ1Zzf1s2AtCXnTqMoTq3Ca9IeAtj83VyEaZgqQAzc=", "test-queue");
        }

        [TestMethod]
        public void Can_Send_AsyncMessage()
        {
            //Arrange
            _queueClientMock.Setup(x => x.SendAsync(It.IsAny<Message>())).Returns(Task.CompletedTask).Verifiable();
            //Act
            _azureQueueService = new AzureQueueSenderService<Helpers.Message>(_azureQueueSettingsService);
            var result = _azureQueueService.SendAsync(new Helpers.Message());
            //Assert
            Assert.IsNull(result.Exception);
        }
    }
}