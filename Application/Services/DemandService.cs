using Domain.ApiDTO.APIResponse;
using Domain.ApiDTO.Demands;
using Domain.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class DemandService : IDemandService
    {
        public Task<ApiResponseDto<DemandReadDto>> Create(DemandCreateDto createDto)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponseDto<bool>> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponseDto<IEnumerable<DemandReadDto>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponseDto<DemandReadDto>> GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponseDto<DemandReadDto>> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponseDto<DemandReadDto>> Update(DemandUpdateDto updateDto)
        {
            throw new NotImplementedException();
        }
    }
}
