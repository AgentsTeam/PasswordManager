using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Domain.Commands
{
    public class PropertyCommand
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Value { get; set; }

        public string Description { get; set; }
    }
}
