using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ApiDTO.Auth
{
    public class LoginResponseDto
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }

        public string TokenID { get; set; }

        public DateTime ExpiresAt { get; set; }
    }
}
