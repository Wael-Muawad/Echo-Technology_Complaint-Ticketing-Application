using Domain.ApiDTO.APIResponse;
using Domain.ApiDTO.Users;
using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IServices
{
    public interface IUserService : IBaseService<UserCreateDto, UserUpdateDto, UserReadDto>
    {
        public Task<ApiResponseDto<UserReadDto>> GetUserByName(string email);
    }
}
