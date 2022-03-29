using Xunit;
using System;
using FluentAssertions;
using NSubstitute;
using PasswordManager.Domain.Contracts;
using PasswordManager.Service;
using PasswordManager.Tests.Unit.Domain.Domains.Builders;
using System.Threading.Tasks;
using PasswordManager.Domain.Domains;
using PasswordManager.Domain.Commands;
using Tynamix.ObjectFiller;
using PasswordManager.Domain.DTOs;

namespace PasswordManager.Tests.Unit.Service
{
    public class PropertyServiceTest
    {
        private readonly IPasswordManagerRepository _repository;
        private readonly PropertyService _propertyService;
        private readonly PropertyTestBuilder _propertyTestBuilder;

        public PropertyServiceTest()
        {
            this._repository = Substitute.For<IPasswordManagerRepository>();
            this._propertyService = new PropertyService(this._repository);
            this._propertyTestBuilder = new PropertyTestBuilder();
        }

        private static PropertyCommand GetCommand()
        {
            var filler = new Filler<PropertyCommand>();
            filler.Setup().OnProperty(x => x.Name).Use("TestName");
            return filler.Create();
        }

        [Fact]
        public void Constructor_ShouldBuildTheRepository()
        {
            var result = new PropertyService(_repository);
            result.Should().NotBeNull();
        }

        [Fact]
        public void Get_ShouldReturnProperty_WhenPassedId()
        { 
            var property = _propertyTestBuilder.Build();
            _repository.GetPropertyAsync(Arg.Any<int>()).Returns(property);
            var propertyExpected = new PropertyGetResponse(property);

            var result = (PropertyGetResponse)_propertyService.Get(property.Id);

            result.Id.Should().Be(propertyExpected.Id);
        }

        [Fact]
        public async Task Add_ShouldCreateANewProperty()
        {
            var command = GetCommand();

            var result = _propertyService.Add(command);

            await _repository.ReceivedWithAnyArgs().AddPropertyAsync(default);
        }

    }
}
