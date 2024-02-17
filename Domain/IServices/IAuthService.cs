using Domain.ApiDTO.APIResponse;
using Domain.ApiDTO.Auth;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IServices
{
    public interface IAuthService
    {
        public Task<bool> IsEmailExist(string email);

        public Task<ApiResponseDto<bool>> IsValidLogin(string email, string password);

        public Task<ApiResponseDto<AppUser>> GetUserByEmail(string email);

        public Task<ApiResponseDto<LoginResponseDto>> Login(string email, string password);
    }
}
