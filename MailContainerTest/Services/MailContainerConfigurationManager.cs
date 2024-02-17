// Ignore Spelling: App

using System.Configuration;

namespace MailContainerTest.Services
{
    internal class MailContainerConfigurationManager : IConfigurationManager
    {
        public string AppSettings => ConfigurationManager.AppSettings["DataStoreType"];
    }
}
