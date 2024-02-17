using Domain.ApiDTO.APIResponse;
using Domain.ApiDTO.Users;
using Domain.IServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;

        public UsersController(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }


        [HttpPost]
        public async Task<IActionResult> Create(UserCreateDto userCreateDto)
        {
            var isEmailExist = await _authService.IsEmailExist(userCreateDto.Email);
            if (isEmailExist)
            {
                var apiRespone = new ApiResponseDto<bool>();
                apiRespone.SetFailureWithError("error", "email already exist.");
                return Conflict(apiRespone);
            }

            var result = await _userService.Create(userCreateDto);

            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetByID(int id)
        {
            var result = await _userService.GetByID(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _userService.GetAll();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(string email, UserUpdateDto userUpdateDto)
        {
            userUpdateDto.SetEmail(email);
            var isEmailExist = await _authService.IsEmailExist(email);
            if (!isEmailExist)
            {
                var apiRespone = new ApiResponseDto<bool>();
                apiRespone.SetFailureWithError("error", "User is not found.");
                return BadRequest(apiRespone);
            }

            var result = await _userService.Update(userUpdateDto);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
