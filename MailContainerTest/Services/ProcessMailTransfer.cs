using MailContainerTest.Data;
using MailContainerTest.Types;

namespace MailContainerTest.Services
{
    public class ProcessMailTransfer : IProcessTransfer<MakeMailTransferResult, MakeMailTransferRequest>
    {

        private readonly IConfigurationManager configurationManager;
        private readonly IResultDeterminer<MakeMailTransferResult> determiner;
        private readonly IFactory<IDataStore, string> factory;
        public ProcessMailTransfer(IConfigurationManager configurationManager,
                                   IResultDeterminer<MakeMailTransferResult> determiner,
                                   IFactory<IDataStore, string> factory)
        {
            this.configurationManager = configurationManager;
            this.determiner = determiner;
            this.factory = factory;
        }

        public MakeMailTransferResult ProcessTransfer(MakeMailTransferRequest request)
        {
            var mailContainerDataStore = factory.Create(configurationManager.AppSettings);
            var mailContainer = mailContainerDataStore.GetMailContainer(request.SourceMailContainerNumber);

            var result = determiner!.Determine(request, mailContainer);

            if (result.Success)
            {
                mailContainer!.Capacity -= request.NumberOfMailItems;
                mailContainerDataStore.UpdateMailContainer(mailContainer);
            }
            return result;
        }
    }
}
