using PasswordManager.Domain.Contracts;
using PasswordManager.Domain.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Domain.DTOs
{
    public class PropertyGetResponse : IResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string Value { get; set; }

        public PropertyGetResponse(Property property)
        {
            Id = property.Id;
            Name = property.Name;
            Description = property.Description;
            Value = property.Value;
        }
    }
}
