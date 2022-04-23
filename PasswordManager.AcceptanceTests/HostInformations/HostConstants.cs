namespace PasswordManager.AcceptanceTests.HostInformations
{
    public static class HostConstants
    {
        public static int Port { get; set; }

        public static readonly string Endpoint = $"https://localhost:{Port}/api";

        public static readonly string CsProjectPath = @"C:\Projects\Password Manager\src\PasswordManager.Api\PasswordManager.Api.csproj";
    }
}
