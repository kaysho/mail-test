using MailContainerTest.Types;

namespace MailContainerTest.Data
{
    public interface IDataStore
    {
        /// <summary>
        /// Get mail container
        /// </summary>
        /// <param name="mailContainerNumber"></param>
        /// <returns></returns>
        MailContainer GetMailContainer(string mailContainerNumber);

        /// <summary>
        /// Update mail container.
        /// </summary>
        /// <param name="mailContainer"></param>
        void UpdateMailContainer(MailContainer mailContainer);
    }
}
