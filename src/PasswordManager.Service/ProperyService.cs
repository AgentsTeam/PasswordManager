﻿using PasswordManager.Common.Helpers;
using PasswordManager.Domain.Commands;
using PasswordManager.Domain.Contracts;
using PasswordManager.Domain.Domains;
using PasswordManager.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Service
{
    public class ProperyService
    {
        private readonly IPasswordManagerRepository _repository;

        public ProperyService(IPasswordManagerRepository repository)
        {
            _repository = repository;
        }

        public IResponse Get(int id)
        {
            var property = _repository.GetProperty(id);
            if (property == null)
            {
                return null;
            }
            return new PropertyGetResponse(property);
        }
        public async Task<IResponse> Add(PropertyCommand command)
        {
            var userId = ContextHelper.GetUserId();
            if (userId == null)
            {
                return null;
            }
            var property = new Property(command.Name, command.Description, command.Value, userId.Value);
            property = await _repository.AddProperty(property);
            if (property == null)
            {
                return null;
            }
            return new PropertyAddResponse(property.Id);
        }
    }
}
