using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ApiDTO.APIResponse
{
    public class ApiResponseDto<TData>
    {
        public bool Success { get; set; }

        public Dictionary<string, string> Errors { get; private set; } = new Dictionary<string, string>();

        public TData Data { get; set; }

        public void SetFailureWithError(string errKey, string errMessage)
        {
            Success = false;
            Errors.Add(errKey, errMessage);
        }

        public void SetSuccessWithPayload(TData data)
        {
            Success = true;
            Data = data;
        }

        public void SetErrors(Dictionary<string, string> errors)
        {
            Errors = errors;
        }
    }
}
