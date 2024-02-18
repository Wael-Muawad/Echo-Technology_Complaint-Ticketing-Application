using Domain.ApiDTO.APIResponse;
using Domain.ApiDTO.Auth;
using Domain.ApiDTO.Users;
using Domain.Entities;
using Domain.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ITokenService _tokenService;
        private readonly UserManager<AppUser> _userManager;

        public AuthController(IAuthService authService, UserManager<AppUser> userManager, ITokenService tokenService)
        {
            _authService = authService;
            _userManager = userManager;
            _tokenService = tokenService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestDto userLoginDto)
        {
            var result = await _authService.Login(userLoginDto.Email, userLoginDto.Password);

            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> RefreshToken(RefreshAccessTokenRequestDto refreshTokenDto)
        {
            var result = await _tokenService.RefreshAccessTokens(refreshTokenDto.JwtToken, refreshTokenDto.RefreshToken);

            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
