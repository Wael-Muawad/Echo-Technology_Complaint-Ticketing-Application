using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ApiDTO.APIResponse
{
    public static class ResponseExtensions
    {
        public static void AddIdentityErrors<TData>(this ApiResponseDto<TData> responseDto, IEnumerable<IdentityError> identityErrors)
        {
            foreach (var error in identityErrors)
            {
                responseDto.SetFailureWithError(error.Code, error.Description);
            }
        }
    }
}
