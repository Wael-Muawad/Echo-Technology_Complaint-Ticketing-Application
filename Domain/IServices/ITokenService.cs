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
    public interface  ITokenService
    {
        public Task<LoginResponseDto> CreateAccessTokens(AppUser user);

        public Task<ApiResponseDto<LoginResponseDto>> RefreshAccessTokens(string token, string refreshToken);

        protected Task<string> CreateRefreshToken(string tokenId, int userId);
    }
}
