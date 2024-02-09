using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Service.Attributes;

namespace WebApp.Service.DTOs.Users
{
    public class UserForCreationDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [UserEmail]
        public string Email { get; set; }
        [UserPassword]
        public string Password { get; set; }
    }
}
