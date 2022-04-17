using PasswordManager.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Domain.Contracts
{
    public interface IPropertyService
    {
        IResponse Get(int id);
        Task<IResponse> AddAsync(PropertyCommand command);
    }
}
