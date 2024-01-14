using Domain.ApiDTO.APIResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public interface IBaseService<TCreateDto, TUpdateDto, TReadDto>
    {
        public Task<ApiResponseDto<TReadDto>> Create(TCreateDto createDto);

        public Task<ApiResponseDto<TReadDto>> Update(TUpdateDto updateDto);

        public Task<ApiResponseDto<bool>> Delete(int id);

        public Task<ApiResponseDto<TReadDto>> GetByID(int id);
        public Task<ApiResponseDto<TReadDto>> GetByName(string name);
        public Task<ApiResponseDto<IEnumerable<TReadDto>>> GetAll();


        public Task<bool> SaveChanges();
    }
}
