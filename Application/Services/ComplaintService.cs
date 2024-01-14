using Domain.ApiDTO.APIResponse;
using Domain.ApiDTO.Complaints;
using Domain.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ComplaintService : IComplaintService
    {
        public Task<ApiResponseDto<ComplaintReadDto>> Create(ComplaintCreateDto createDto)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponseDto<bool>> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponseDto<IEnumerable<ComplaintReadDto>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponseDto<ComplaintReadDto>> GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponseDto<ComplaintReadDto>> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponseDto<ComplaintReadDto>> Update(ComplaintUpdateDto updateDto)
        {
            throw new NotImplementedException();
        }
    }
}
