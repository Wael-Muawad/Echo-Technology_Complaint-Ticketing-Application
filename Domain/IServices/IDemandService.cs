using Domain.ApiDTO.APIResponse;
using Domain.ApiDTO.Demands;
using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IServices
{
    public interface IDemandService : IBaseService<DemandCreateDto, DemandUpdateDto, DemandReadDto>
    {
        public Task<ApiResponseDto<IEnumerable<DemandReadDto>>> GetAllByComplaint(int complaintID);
    }
}
