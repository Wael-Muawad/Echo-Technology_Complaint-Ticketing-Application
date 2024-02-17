using Domain.ApiDTO.APIResponse;
using Domain.ApiDTO.RefreshTokens;
using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IServices
{
    public interface IRefreshTokenService :
        IBaseService<RefreshTokenCreateDto, RefreshTokenUpdateDto, RefreshTokenReadDto>
    {

        public Task<ApiResponseDto<RefreshTokenReadDto>> GetByToken(string token);
    }
}
