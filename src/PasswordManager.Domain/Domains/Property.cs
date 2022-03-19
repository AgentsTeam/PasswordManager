using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Domain.Domains
{
    public class Property
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string Value { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }

        public Property(string name, string description, string value, Guid userId)
        {
            ValidateStringData(name);
            ValidateStringData(description);
            ValidateStringData(value);
            ValidateGuidData(userId);

            Name = name;
            Description = description;
            Value = value;
            UserId = userId;
        }

        private void ValidateStringData(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentNullException(nameof(input));
        }

        private void ValidateGuidData(Guid? input)
        {
            if (input == null || input == Guid.Empty)
                throw new ArgumentNullException(nameof(input));
        }
    }
}
