using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Domain.Commons;
using WebApp.Domain.Enums;

namespace WebApp.Domain.Entities.Users
{
    public class User : Auditable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole UserRole { get; set; }
    }
}
