namespace PasswordManager.Domain.Commands
{
    public class UserLoginCommand
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
