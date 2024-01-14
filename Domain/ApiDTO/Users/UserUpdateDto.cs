using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ApiDTO.Users
{
    public class UserUpdateDto
    {
        public string? Email { get; private set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Password { get; set; }

        public void SetEmail(string email)
        {
            Email = email;
        }
    }
}
