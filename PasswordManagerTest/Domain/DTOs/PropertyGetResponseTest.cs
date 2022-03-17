using PasswordManager.Domain.Domains;
using PasswordManager.Domain.DTOs;
using System;
using Xunit;

namespace PasswordManagerTest.Domain.DTOs
{
    public class PropertyGetResponseTest
    {
        [Fact]
        public void Constructor_ShouldConstructPropertyProperly()
        {
            var property = new Property("TestName", "TestDesc", "TestValue", Guid.NewGuid());
            var result = new PropertyGetResponse(property);
            Assert.NotNull(result);
            Assert.Equal(property.Name, result.Name);
            Assert.Equal(property.Description, result.Description);
            Assert.Equal(property.Id, result.Id);
            Assert.Equal(property.Value,result.Value);
        }
    }
}
