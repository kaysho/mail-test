namespace MailContainerTest.Services
{
    public interface IFactory<T, TR>
    {
        T Create(TR value);
    }
}
