using AutoMapper;
using Domain.ApiDTO.APIResponse;
using Domain.ApiDTO.Demands;
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
    public class DemandService : IDemandService
    {

        private readonly IDemandRepo _demandRepo;
        private readonly IMapper _mapper;

        public DemandService(IDemandRepo demandRepo, IMapper mapper)
        {
            _demandRepo = demandRepo;
            _mapper = mapper;
        }


        public async Task<ApiResponseDto<DemandReadDto>> Create(DemandCreateDto createDto)
        {
            var apiResponseDto = new ApiResponseDto<DemandReadDto>();

            if (createDto == null)
            {
                apiResponseDto.SetFailureWithError("Error On Create", "The create object is null");
                return apiResponseDto;
            }

            try
            {
                var entity = _mapper.Map<Demand>(createDto);
                entity.CreatedAt = DateTime.UtcNow;
                await _demandRepo.Create(entity);
                var isChanged = await SaveChanges();

                if (isChanged)
                {
                    var readDto = _mapper.Map<DemandReadDto>(entity);
                    apiResponseDto.SetSuccessWithPayload(readDto);
                }
                else
                    apiResponseDto.SetFailureWithError("Error On Create", "Faield to create");
            }
            catch (Exception ex)
            {
                apiResponseDto.SetFailureWithError("Error On Create", ex.Message);
                if (ex.InnerException != null)
                    apiResponseDto.SetFailureWithError("InnerException", ex.InnerException.Message);

            }

            return apiResponseDto;
        }

        public async Task<ApiResponseDto<bool>> Delete(int id)
        {
            var apiResponseDto = new ApiResponseDto<bool>();

            try
            {
                await _demandRepo.Delete(id);
                var isChanged = await SaveChanges();

                if (isChanged)
                    apiResponseDto.SetSuccessWithPayload(true);
                else
                    apiResponseDto.SetFailureWithError("Error On Delete", "Faield to SaveChanges in delete");
            }
            catch (Exception ex)
            {
                apiResponseDto.SetFailureWithError("Error On Delete", ex.Message);
                if (ex.InnerException != null)
                    apiResponseDto.SetFailureWithError("InnerException", ex.InnerException.Message);
            }

            return apiResponseDto;
        }

        public async Task<ApiResponseDto<IEnumerable<DemandReadDto>>> GetAll()
        {
            var apiResponseDto = new ApiResponseDto<IEnumerable<DemandReadDto>>();

            try
            {
                var entities = await _demandRepo.GetAll();
                if (entities is null)
                    apiResponseDto.SetFailureWithError("Error On Get", "The entity is null");
                else
                {
                    var result = entities.Select(e => _mapper.Map<DemandReadDto>(e));
                    apiResponseDto.SetSuccessWithPayload(result);
                }
            }
            catch (Exception ex)
            {
                apiResponseDto.SetFailureWithError("Error On Get", ex.Message);
                if (ex.InnerException != null)
                    apiResponseDto.SetFailureWithError("InnerException", ex.InnerException.Message);
            }

            return apiResponseDto;
        }

        public async Task<ApiResponseDto<IEnumerable<DemandReadDto>>> GetAllByComplaint(int complaintID)
        {
            var apiResponseDto = new ApiResponseDto<IEnumerable<DemandReadDto>>();

            try
            {
                var entities = await _demandRepo.GetAllByComplaint(complaintID);
                if (entities is null)
                    apiResponseDto.SetFailureWithError("Error On Get", "The entity is null");
                else
                {
                    var result = entities.Select(e => _mapper.Map<DemandReadDto>(e));
                    apiResponseDto.SetSuccessWithPayload(result);
                }
            }
            catch (Exception ex)
            {
                apiResponseDto.SetFailureWithError("Error On Get", ex.Message);
                if (ex.InnerException != null)
                    apiResponseDto.SetFailureWithError("InnerException", ex.InnerException.Message);
            }

            return apiResponseDto;
        }

        public async Task<ApiResponseDto<DemandReadDto>> GetByID(int id)
        {
            var apiResponseDto = new ApiResponseDto<DemandReadDto>();

            try
            {
                var entity = await _demandRepo.GetByID(id);
                if (entity is null)
                    apiResponseDto.SetFailureWithError("Error On Get", $"entity of id {id} is not found");
                
                else
                {
                    var readeDto = _mapper.Map<DemandReadDto>(entity);
                    apiResponseDto.SetSuccessWithPayload(readeDto);
                }
            }
            catch (Exception ex)
            {
                apiResponseDto.SetFailureWithError("Error On Get", ex.Message);
                if (ex.InnerException != null)
                    apiResponseDto.SetFailureWithError("InnerException", ex.InnerException.Message);
            }

            return apiResponseDto;
        }

        public Task<ApiResponseDto<DemandReadDto>> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveChanges()
        {
            return await _demandRepo.SaveChanges();
        }

        public async Task<ApiResponseDto<DemandReadDto>> Update(DemandUpdateDto updateDto)
        {
            var apiResponseDto = new ApiResponseDto<DemandReadDto>();

            if (updateDto == null)
            {
                apiResponseDto.SetFailureWithError("Error On Update", "The entity is null");
                return apiResponseDto;
            }

            try
            {
                var entity = _mapper.Map<Demand>(updateDto);
                entity.UpdatedAt = DateTime.UtcNow;
                await _demandRepo.Update(entity);
                var isChanged = await SaveChanges();

                if (isChanged)
                {
                    var readDto = _mapper.Map<DemandReadDto>(updateDto);
                    apiResponseDto.SetSuccessWithPayload(readDto);
                }
                else
                    apiResponseDto.SetFailureWithError("Error On Update", "Faield to update");
            }
            catch (Exception ex)
            {
                apiResponseDto.SetFailureWithError("Error On Update", ex.Message);
                if (ex.InnerException != null)
                    apiResponseDto.SetFailureWithError("InnerException", ex.InnerException.Message);
            }

            return apiResponseDto;
        }
    }
}
