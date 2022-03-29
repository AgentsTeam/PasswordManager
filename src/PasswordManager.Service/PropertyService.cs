using PasswordManager.Common.Helpers;
using PasswordManager.Domain.Commands;
using PasswordManager.Domain.Contracts;
using PasswordManager.Domain.Domains;
using PasswordManager.Domain.DTOs;
using System;

namespace PasswordManager.Service
{
    public class PropertyService
    {
        private readonly IPasswordManagerRepository _repository;

        public PropertyService(IPasswordManagerRepository repository)
        {
            _repository = repository;
        }

        public IResponse Get(int id)
        {
            var property = _repository.GetPropertyAsync(id);
            if (property == null)
            {
                return null;
            }
            return new PropertyGetResponse(property.Result);
        }
        public async Task<IResponse> Add(PropertyCommand command)
        {
            var userId = ContextHelper.GetUserId();
            if (userId == null)
            {
                return null;
            }
            var property = new Property(command.Name, command.Description, command.Value, userId.Value);
            property = await _repository.AddPropertyAsync(property);
            if (property == null)
            {
                return null;
            }
            return new PropertyAddResponse(property.Id);
        }
    }
}
