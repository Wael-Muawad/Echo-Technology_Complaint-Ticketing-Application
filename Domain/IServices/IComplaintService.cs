using Domain.ApiDTO.APIResponse;
using Domain.ApiDTO.Complaints;
using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IServices
{
    public interface IComplaintService : IBaseService<ComplaintCreateDto, ComplaintUpdateDto, ComplaintReadDto>
    {
    }
}
