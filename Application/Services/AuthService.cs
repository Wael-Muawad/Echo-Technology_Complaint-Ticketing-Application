using Domain.ApiDTO.APIResponse;
using Domain.ApiDTO.Auth;
using Domain.Entities;
using Domain.IServices;
using Microsoft.AspNetCore.Identity;


namespace Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;

        public AuthService(UserManager<AppUser> userManager,
                           SignInManager<AppUser> signInManager,
                           ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }


        public async Task<bool> IsEmailExist(string email)
        {
            return (await GetIdentityUser(email) != null);
        }

        public async Task<ApiResponseDto<bool>> IsValidLogin(string email, string password)
        {
            var apiResponseDto = new ApiResponseDto<bool>();
            var user = await GetIdentityUser(email);

            if (user is null)
                apiResponseDto.SetFailureWithError("error", "The accont is not exist");
            else
            {
                var signInResult = await _signInManager.CheckPasswordSignInAsync(user, password, false);
                if (signInResult.Succeeded)
                    apiResponseDto.SetSuccessWithPayload(true);
                else
                    apiResponseDto.SetFailureWithError("error", "Wrong credentials.");
            }

            return apiResponseDto;
        }

        public Task<bool> IsUserLogedIn(string userEmail)
        {
            //_userManager.
            throw new NotImplementedException();
        }

        public async Task<ApiResponseDto<AppUser>> GetUserByEmail(string email)
        {
            var apiResponseDto = new ApiResponseDto<AppUser>();
            var user = await GetIdentityUser(email);

            if (user is null)
                apiResponseDto.SetFailureWithError("error", "The accont is not exist");
            else
                apiResponseDto.SetSuccessWithPayload(user);

            return apiResponseDto;
        }


        public async Task<ApiResponseDto<LoginResponseDto>> Login(string email, string password)
        {
            var apiResponse = new ApiResponseDto<LoginResponseDto>();

            var isValidResult = await IsValidLogin(email, password);
            if (!isValidResult.Success)
            {
                apiResponse.SetErrors(isValidResult.Errors);
                return apiResponse;
            }

            var getUserResult = await GetUserByEmail(email);
            if (!getUserResult.Success)
            {
                apiResponse.SetErrors(getUserResult.Errors);
                return apiResponse;
            }

            var loginResponseDto = await _tokenService.CreateAccessTokens(getUserResult.Data);
            apiResponse.SetSuccessWithPayload(loginResponseDto);

            return apiResponse;
        }



        private async Task<AppUser?> GetIdentityUser(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

    }
}
