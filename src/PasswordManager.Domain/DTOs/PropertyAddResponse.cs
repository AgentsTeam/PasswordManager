using PasswordManager.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Domain.DTOs
{
    public class PropertyAddResponse : IResponse
    {
        public int Id { get; set; }

        public PropertyAddResponse(int id)
        {
            Id = id;
        }
    }
}
