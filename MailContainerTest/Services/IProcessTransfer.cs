namespace MailContainerTest.Services
{
    public interface IProcessTransfer<T, TR>
    {
        /// <summary>
        /// Process transfer
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        T ProcessTransfer(TR request);
    }
}