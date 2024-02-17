using MailContainerTest.Types;

namespace MailContainerTest.Services
{
    public interface IResultDeterminer<T>
    {
        public T Determine(MakeMailTransferRequest request, MailContainer mailContainer);
    }
}