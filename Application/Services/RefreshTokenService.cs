using AutoMapper;
using Domain.ApiDTO.APIResponse;
using Domain.ApiDTO.RefreshTokens;
using Domain.Entities;
using Domain.IRepositories;
using Domain.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class RefreshTokenService : IRefreshTokenService
    {
        private readonly IRefreshTokenRepo _repo;
        private readonly IMapper _mapper;


        public RefreshTokenService(IRefreshTokenRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponseDto<RefreshTokenReadDto>> Create(RefreshTokenCreateDto createDto)
        {
            var apiResponseDto = new ApiResponseDto<RefreshTokenReadDto>();
            try
            {
                var entity = _mapper.Map<RefreshToken>(createDto);
                entity.CreationDate = DateTime.UtcNow;
                await _repo.Create(entity);
                var isChanged = await _repo.SaveChanges();

                if (isChanged)
                {
                    var readDto = _mapper.Map<RefreshTokenReadDto>(entity);
                    apiResponseDto.SetSuccessWithPayload(readDto);
                }
                else
                    apiResponseDto.SetFailureWithError("error", "Faield to create");
            }
            catch (Exception ex)
            {
                apiResponseDto.SetFailureWithError("error", ex.Message);
                if (ex.InnerException is not null)
                {
                    apiResponseDto.SetFailureWithError("InnerException", ex.InnerException.Message);
                }
            }

            return apiResponseDto;
        }

        public Task<ApiResponseDto<bool>> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponseDto<IEnumerable<RefreshTokenReadDto>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponseDto<RefreshTokenReadDto>> GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponseDto<RefreshTokenReadDto>> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponseDto<RefreshTokenReadDto>> GetByToken(string token)
        {
            var apiResponse = new ApiResponseDto<RefreshTokenReadDto>();
            try
            {
                var result = await _repo.GetByToken(token);
                var dto = _mapper.Map<RefreshToken, RefreshTokenReadDto>(result);
                apiResponse.SetSuccessWithPayload(dto);
            }
            catch (Exception ex)
            {

                throw;
            }

            return apiResponse;
        }

        public async Task<bool> SaveChanges()
        {
            return await _repo.SaveChanges();
        }

        public Task<ApiResponseDto<RefreshTokenReadDto>> Update(RefreshTokenUpdateDto updateDto)
        {
            throw new NotImplementedException();
        }
    }
}
