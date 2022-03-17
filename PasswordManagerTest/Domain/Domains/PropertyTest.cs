using PasswordManager.Domain.Domains;
using System;
using Xunit;

namespace PasswordManagerTest.Domain.Domains
{
    
    public class PropertyTest
    {
        [Fact]
        public void Constructor_ShouldConstructPropertyProperly()
        {
            string name = "TestName";
            string description = "TestDesc";
            string value = "TestValue";
            Guid userId = Guid.NewGuid();

            var result = new Property(name, description, value, userId);
            Assert.Equal(name, result.Name);
            Assert.Equal(description, result.Description);
            Assert.Equal(value, result.Value);
            Assert.Equal(userId, result.UserId);
        }
    }
}
