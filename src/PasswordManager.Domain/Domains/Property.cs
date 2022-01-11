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
            Name = name;
            Description = description;
            Value = value;
            UserId = userId;
        }
    }
}
