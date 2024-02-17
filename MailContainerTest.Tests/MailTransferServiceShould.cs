using FluentAssertions;
using MailContainerTest.Data;
using MailContainerTest.Services;
using MailContainerTest.Types;
using Moq;
using Xunit;

namespace MailContainerTest.Tests
{
    public class MailTransferServiceShould
    {
        private readonly Mock<IConfigurationManager> mockConfigurationManager;
        private readonly Mock<IResultDeterminer<MakeMailTransferResult>> mockResultDeterminer;
        private readonly IProcessTransfer<MakeMailTransferResult, MakeMailTransferRequest> processMailTransfer;
        private readonly Mock<IFactory<IDataStore, string>> mockFactory;
        private readonly MailTransferService sut;
        public MailTransferServiceShould()
        {
            mockConfigurationManager = new Mock<IConfigurationManager>();
            mockResultDeterminer = new Mock<IResultDeterminer<MakeMailTransferResult>>();
            mockFactory = new Mock<IFactory<IDataStore, string>>();
            processMailTransfer = new ProcessMailTransfer(mockConfigurationManager.Object, mockResultDeterminer.Object, mockFactory.Object);

            sut = new MailTransferService(processMailTransfer);
        }

        [Fact]
        public void ProcessMakeMailTransferResult()
        {
            //Arrange
            var makeMailTransferResult = new MakeMailTransferResult
            {
                Success = false
            };
            mockConfigurationManager.Setup(c => c.AppSettings).Returns("Backup");
            mockFactory.Setup(f => f.Create(It.IsAny<string>())).Returns(new BackupMailContainerDataStore());
            mockResultDeterminer.Setup(d => d.Determine(It.IsAny<MakeMailTransferRequest>(), It.IsAny<MailContainer>())).Returns(makeMailTransferResult);
            var makeMailTransferRequest = new MakeMailTransferRequest
            {
                DestinationMailContainerNumber = "ASDT",
                MailType = MailType.StandardLetter,
                NumberOfMailItems = 1000,
                SourceMailContainerNumber = "LKJ",
                TransferDate = DateTime.Now
            };

            //Act
            var result = sut.MakeMailTransfer(makeMailTransferRequest);

            //Assert
            result.Success.Should().Be(makeMailTransferResult.Success);
        }
    }
}
