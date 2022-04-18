
namespace PasswordManager.Domain.Domains
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime CreateDate { get; set; }
        public List<Property> Properties { get; set; }

        public User(string userName, string password)
        {
            ValidateStringData(userName);
            ValidateStringData(password);

            Id = Guid.NewGuid();
            UserName = userName;
            Password = password;
            CreateDate = DateTime.UtcNow;
            Properties = new List<Property>();
        }

        public User(string firstName, string lastName, string email, string userName, string password, DateTime createDate)
        {
            ValidateStringData(firstName);
            ValidateStringData(lastName);
            ValidateStringData(userName);
            ValidateStringData(password);
            ValidateDateTimeData(createDate);

            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            UserName = userName;
            Password = password;
            CreateDate = createDate;
            Properties = new List<Property>();
        }

        private void ValidateStringData(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentNullException(nameof(input));
        }

        private void ValidateDateTimeData(DateTime input)
        {
            if (input == DateTime.MinValue || input == DateTime.UnixEpoch || input == DateTime.MaxValue)
                throw new ArgumentNullException(nameof(input));
        }

        public void AddProperty(Property property)
        { 
            Properties.Add(property);
        }
    }
}
