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
        public async Task Get_ShouldReturnProperty_WhenPassedId()
        { 
            var property = _propertyTestBuilder.Build();
            _repository.AddPropertyAsync(Arg.Any<Property>()).Returns(property);
            var propertyCreated = await _repository.AddPropertyAsync(property);

            var result = _propertyService.Get(propertyCreated.Id);

            result.Should().Be(propertyCreated);
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
