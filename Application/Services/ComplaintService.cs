using AutoMapper;
using Domain.ApiDTO.APIResponse;
using Domain.ApiDTO.Complaints;
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
    public class ComplaintService : IComplaintService
    {
        private readonly IComplaintRepo _complaintRepo;
        private readonly IMapper _mapper;

        public ComplaintService(IComplaintRepo complaintRepo, IMapper mapper)
        {
            _complaintRepo = complaintRepo;
            _mapper = mapper;
        }

        public async Task<ApiResponseDto<ComplaintReadDto>> Create(ComplaintCreateDto createDto)
        {
            var apiResponseDto = new ApiResponseDto<ComplaintReadDto>();

            if (createDto == null)
            {
                apiResponseDto.SetFailureWithError("Error On Create", "The create object is null");
                return apiResponseDto;
            }

            try
            {
                var entity = _mapper.Map<Complaint>(createDto);
                entity.CreatedAt = DateTime.UtcNow;
                await _complaintRepo.Create(entity);
                var isChanged = await SaveChanges();

                if (isChanged)
                {
                    var readDto = _mapper.Map<ComplaintReadDto>(entity);
                    apiResponseDto.SetSuccessWithPayload(readDto);
                }
                else
                    apiResponseDto.SetFailureWithError("Error On Create", "Faield to create");
            }
            catch (Exception ex)
            {
                apiResponseDto.SetFailureWithError("Error On Create", ex.Message);
            }

            return apiResponseDto;
        }

        public async Task<ApiResponseDto<bool>> Delete(int id)
        {
            var apiResponseDto = new ApiResponseDto<bool>();

            try
            {
                await  _complaintRepo.Delete(id);
                var isChanged = await SaveChanges();

                if (isChanged)
                    apiResponseDto.SetSuccessWithPayload(true);
                else
                    apiResponseDto.SetFailureWithError("Error On Delete", "Faield to SaveChanges in delete");
            }
            catch (Exception ex)
            {
                apiResponseDto.SetFailureWithError("Error On Delete", ex.Message);
            }

            return apiResponseDto;
        }

        public async Task<ApiResponseDto<IEnumerable<ComplaintReadDto>>> GetAll()
        {
            var apiResponseDto = new ApiResponseDto<IEnumerable<ComplaintReadDto>>();

            try
            {
                var entities = await _complaintRepo.GetAll();
                if (entities is null)
                    apiResponseDto.SetFailureWithError("Error On Get", "The entity is null");
                else
                {
                    var result = entities.Select(e => _mapper.Map<ComplaintReadDto>(e));
                    apiResponseDto.SetSuccessWithPayload(result);
                }
            }
            catch (Exception ex)
            {
                apiResponseDto.SetFailureWithError("Error On Get", ex.Message);
            }

            return apiResponseDto;
        }

        public async Task<ApiResponseDto<ComplaintReadDto>> GetByID(int id)
        {
            var apiResponseDto = new ApiResponseDto<ComplaintReadDto>();

            try
            {
                var entity = await _complaintRepo.GetByID(id);
                if (entity is null)
                    apiResponseDto.SetFailureWithError("Error On Get", $"entity of id {id} is not found");

                else
                {
                    var readeDto = _mapper.Map<ComplaintReadDto>(entity);
                    apiResponseDto.SetSuccessWithPayload(readeDto);
                }
            }
            catch (Exception ex)
            {
                apiResponseDto.SetFailureWithError("Error On Get", ex.Message);
            }

            return apiResponseDto;
        }

        public Task<ApiResponseDto<ComplaintReadDto>> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveChanges()
        {
            return await _complaintRepo.SaveChanges();
        }

        public async Task<ApiResponseDto<ComplaintReadDto>> Update(ComplaintUpdateDto updateDto)
        {
            var apiResponseDto = new ApiResponseDto<ComplaintReadDto>();

            if (updateDto == null)
            {
                apiResponseDto.SetFailureWithError("Error On Update", "The entity is null");
                return apiResponseDto;
            }

            try
            {
                var entity = _mapper.Map<Complaint>(updateDto);
                entity.UpdatedAt = DateTime.UtcNow;
                await _complaintRepo.Update(entity);
                var isChanged = await SaveChanges();

                if (isChanged)
                {
                    var readDto = _mapper.Map<ComplaintReadDto>(updateDto);
                    apiResponseDto.SetSuccessWithPayload(readDto);
                }
                else
                    apiResponseDto.SetFailureWithError("Error On Update", "Faield to update");
            }
            catch (Exception ex)
            {
                apiResponseDto.SetFailureWithError("Error On Update", ex.Message);
            }

            return apiResponseDto;
        }
    }
}
