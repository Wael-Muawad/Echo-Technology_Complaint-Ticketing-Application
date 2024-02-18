using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ApiDTO.Auth
{
    public class RefreshAccessTokenRequestDto
    {
        public string JwtToken { get; set; }

        public string RefreshToken { get; set; }
    }
}
