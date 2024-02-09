using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Service.DTOs.Users
{
    public class UserForUpdateDTO
    {
        [Required]
        public string Email { get; set; }
    }
}
