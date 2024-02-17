using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.ApiDTO.APIResponse;
using Domain.ApiDTO.Users;
using Domain.Entities;
using Domain.IServices;
using Microsoft.AspNetCore.Identity;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IMapper _mapper;

        public UserService(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task<ApiResponseDto<UserReadDto>> Create(UserCreateDto createDto)
        {
            var apiResponseDto = new ApiResponseDto<UserReadDto>();

            try
            {
                var user = GetNewIdentityUser(createDto);

                var identityResult = await _userManager.CreateAsync(user, createDto.Password);
                if (identityResult.Succeeded)
                {
                    var readDto = _mapper.Map<UserReadDto>(user);
                    await AddUserToUserRole(user, readDto, apiResponseDto);
                }

                else
                    apiResponseDto.AddIdentityErrors(identityResult.Errors);

            }
            catch (Exception ex)
            {
                apiResponseDto.SetFailureWithError("Error On Create", ex.Message);
            }

            return apiResponseDto;
        }

        public async Task<ApiResponseDto<UserReadDto>> Update(UserUpdateDto updateDto)
        {
            var apiResponseDto = new ApiResponseDto<UserReadDto>();

            try
            {
                var userToEdit = await _userManager.FindByEmailAsync(updateDto.Email);

                UpdateUserProperties(userToEdit, updateDto);
                var identityResult = await _userManager.UpdateAsync(userToEdit);

                if (identityResult.Succeeded)
                {
                    var readDto = _mapper.Map<UserReadDto>(userToEdit);
                    apiResponseDto.SetSuccessWithPayload(readDto);
                }

                else
                    apiResponseDto.AddIdentityErrors(identityResult.Errors);
            }
            catch (Exception ex)
            {
                apiResponseDto.SetFailureWithError("Error On Update", ex.Message);
            }

            return apiResponseDto;
        }


        public Task<ApiResponseDto<bool>> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponseDto<IEnumerable<UserReadDto>>> GetAll()
        {
            var apiResponseDto = new ApiResponseDto<IEnumerable<UserReadDto>>();
            var users = _userManager.Users.ToList();
            var usersReadDto = users.Select(u => _mapper.Map<UserReadDto>(u));
            apiResponseDto.SetSuccessWithPayload(usersReadDto);

            await Task.Yield();
            return apiResponseDto;
        }

        public async Task<ApiResponseDto<UserReadDto>> GetByID(int id)
        {
            var apiResponseDto = new ApiResponseDto<UserReadDto>();

            try
            {
                var user = await _userManager.FindByIdAsync(id.ToString());
                if (user == null)
                    apiResponseDto.SetFailureWithError("Error On Find", "User is not found.");
                else
                {
                    var userReadDto = _mapper.Map<UserReadDto>(user);
                    apiResponseDto.SetSuccessWithPayload(userReadDto);
                }
            }
            catch (Exception ex)
            {
                apiResponseDto.SetFailureWithError("Error On Find", ex.Message);
            }

            return apiResponseDto;
        }
        public Task<ApiResponseDto<UserReadDto>> GetByName(string name)
        {
            throw new NotImplementedException();
        }
        public async Task<ApiResponseDto<UserReadDto>> GetUserByName(string email)
        {
            var apiResponseDto = new ApiResponseDto<UserReadDto>();

            try
            {
                var user = await _userManager.FindByEmailAsync(email);
                if (user == null)
                    apiResponseDto.SetFailureWithError("Error On Find", "User is not found.");
                else
                {
                    var userReadDto = _mapper.Map<UserReadDto>(user);
                    apiResponseDto.SetSuccessWithPayload(userReadDto);
                }
            }
            catch (Exception ex)
            {
                apiResponseDto.SetFailureWithError("Error On Find", ex.Message);
            }

            return apiResponseDto;
        }

        public Task<bool> SaveChanges()
        {
            throw new NotImplementedException();
        }


        internal void UpdateUserProperties(AppUser userToEdit, UserUpdateDto updateDto)
        {
            var hasher = new PasswordHasher<AppUser>();

            userToEdit.PhoneNumber = updateDto.PhoneNumber;
            userToEdit.PasswordHash = hasher.HashPassword(userToEdit, updateDto.Password);
        }

        internal AppUser GetNewIdentityUser(UserCreateDto createDto)
        {
            var user = new AppUser
            {
                UserName = createDto.UserName,
                Email = createDto.Email,
                PhoneNumber = createDto.PhoneNumber
            };
            return user;
        }

        internal async Task AddUserToUserRole(AppUser user, UserReadDto userCreateDto, ApiResponseDto<UserReadDto> apiResponseDto)
        {
            var identityResult = await _userManager.AddToRoleAsync(user, "User");
            if (identityResult.Succeeded)
            {
                apiResponseDto.SetSuccessWithPayload(userCreateDto);
            }
            else
            {
                //await _userManager.DeleteAsync(user);
                apiResponseDto.Success = false;
                apiResponseDto.AddIdentityErrors(identityResult.Errors);
            }
        }

        
    }
}
