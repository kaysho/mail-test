using MailContainerTest.Types;

namespace MailContainerTest.Services
{
    /// <summary>
    /// To ensure this code is highly testable and maintainable, we have to incorporate some design patterns and development principle.
    /// </summary>
    public class MailTransferService : IMailTransferService
    {
        private readonly IProcessTransfer<MakeMailTransferResult, MakeMailTransferRequest> process;
        public MailTransferService(IProcessTransfer<MakeMailTransferResult, MakeMailTransferRequest> process)
        {
            this.process = process;
        }
        public MakeMailTransferResult MakeMailTransfer(MakeMailTransferRequest request) => process.ProcessTransfer(request);
    }
}
