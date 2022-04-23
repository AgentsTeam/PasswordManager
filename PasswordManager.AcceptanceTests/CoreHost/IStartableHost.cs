namespace PasswordManager.AcceptanceTests.CoreHost
{
    public interface IStartableHost : IHost
    {
        void Start();

        void Stop();
    }
}
