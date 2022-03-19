using PasswordManager.Domain.Domains;
using System;


namespace PasswordManager.Tests.Domain.Domains
{
    internal class PropertyTestBuilder
    {
        string Name { get; set; } = "TestName";
        string Description { get; set; } = "TestDesc";
        string Value { get; set; } = "TestValue";
        Guid UserId { get; set; } = Guid.NewGuid();

        public PropertyTestBuilder WithName(string name)
        { 
            this.Name = name;
            return this;
        }

        public PropertyTestBuilder WithDescription(string description)
        {
            this.Description = description;
            return this;
        }

        public PropertyTestBuilder WithValue(string value)
        {
            this.Value = value;
            return this;
        }

        public PropertyTestBuilder WithUserId(Guid userId)
        {
            this.UserId = userId;
            return this;
        }

        public Property Build()
        {
            return new Property(Name,Description,Value,UserId);
        }
    }
}
