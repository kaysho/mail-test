using MailContainerTest.Services;

namespace MailContainerTest.Data
{
    public class DataStoreFactory : IFactory<IDataStore, string>
    {
        public IDataStore Create(string type) => type == "Backup" ? new BackupMailContainerDataStore() : new MailContainerDataStore();
    }
}
