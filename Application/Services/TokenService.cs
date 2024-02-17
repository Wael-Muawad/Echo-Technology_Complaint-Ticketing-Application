using Domain.ApiDTO.APIResponse;
using Domain.ApiDTO.Auth;
using Domain.ApiDTO.RefreshTokens;
using Domain.Common;
using Domain.Entities;
using Domain.IServices;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TokenService : ITokenService
    {

        private readonly JwtSettings _jwtSettings;
        private readonly TokenValidationParameters _tokenValidationParameters;
        private readonly IRefreshTokenService _refreshTokenService;

        public TokenService(
            JwtSettings jwtSettings,
            TokenValidationParameters tokenValidationParameters,
            IRefreshTokenService refreshTokenService)
        {
            _jwtSettings = jwtSettings;
            _tokenValidationParameters = tokenValidationParameters;
            _refreshTokenService = refreshTokenService;
        }


        public async Task<LoginResponseDto> CreateAccessTokens(AppUser user)
        {
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            var claims = GetClaims(user);
            var credentials = GetSigningCredentials();
            var tokenDescriptor = GetSecurityTokenDescriptor(claims, credentials);

            var jwtSecurityToken = jwtSecurityTokenHandler.CreateToken(tokenDescriptor);
            var refreshToken = await CreateRefreshToken(jwtSecurityToken.Id, user.Id);
            var jwtToken = jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);
            return new LoginResponseDto
            {
                Token = jwtToken,
                RefreshToken = refreshToken,
                TokenID = jwtSecurityToken.Id,
                ExpiresAt = jwtSecurityToken.ValidTo
            };
        }

        public async Task<ApiResponseDto<LoginResponseDto>> RefreshAccessTokens(string token, string refreshToken)
        {
            var apiRespone = new ApiResponseDto<LoginResponseDto>();

            var claimsFromToken = GetPrincipalFromToken(token);

            if (claimsFromToken is null)
            {
                apiRespone.SetFailureWithError("error", "ClaimsFromToken are invalid");
                return apiRespone;
            }

            Func<Claim, bool> expiryPredicate = c => c.Type == JwtRegisteredClaimNames.Exp;
            Func<Claim, bool> JtiPredicate = c => c.Type == JwtRegisteredClaimNames.Jti;

            var tokenExpiryDateUnix =
                long.Parse(claimsFromToken.Claims.Single(expiryPredicate).Value);

            var tokenExpiryDateUtc =
                new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                .AddSeconds(tokenExpiryDateUnix);

            if (tokenExpiryDateUtc > DateTime.UtcNow)
            {
                apiRespone.SetFailureWithError("error", "Access token hasn't expired yet");
                return apiRespone;
            }

            var resultStoredRefreshToken = await _refreshTokenService.GetByToken(refreshToken);
            var storedRedreshToken = resultStoredRefreshToken.Data;
            if (storedRedreshToken is null)
            {
                apiRespone.SetFailureWithError("error", "Refresh token doesn't exist");
                return apiRespone;
            }


            if (DateTime.UtcNow > storedRedreshToken.ExpiryDate)
            {
                apiRespone.SetFailureWithError("error", "Refresh token has expired");
                return apiRespone;
            }

            if (storedRedreshToken.IsRevoked)
            {
                apiRespone.SetFailureWithError("error", "RefreshToken is not valid");
                return apiRespone;
            }

            if (storedRedreshToken.IsUsed)
            {
                apiRespone.SetFailureWithError("error", "RefreshToken is used");
                return apiRespone;
                //refreshToken is used
            }

            var jti = claimsFromToken.Claims.Single(JtiPredicate).Value;
            if (storedRedreshToken.JwtId != jti)
            {
                //refreshToken is used
            }

            storedRedreshToken.IsUsed = true;


            return null;
        }



        public async Task<string> CreateRefreshToken(string tokenId, int userId)
        {
            var refreshToken = GenerateRefreshToken();

            var refreshTokenCreateDto = new RefreshTokenCreateDto
            {
                JwtId = tokenId,
                UserId = userId,
                Token = refreshToken,
                IsUsed = false, 
                IsRevoked = false,
                ExpiryDate = DateTime.UtcNow.AddDays(15)
            };

            await _refreshTokenService.Create(refreshTokenCreateDto);

            return refreshToken;
        }









        //CreateJwtToken
        private List<Claim> GetClaims(AppUser user)
        {
            //1- create list of claims
            return new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("userid", user.Id.ToString()),
            };
        }

        private SigningCredentials GetSigningCredentials()
        {
            //2- create SigningCredentials object 
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));
            return new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
        }

        private SecurityTokenDescriptor GetSecurityTokenDescriptor(List<Claim> claims, SigningCredentials credentials)
        {
            //3- or create tokenDescriptor
            return new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                SigningCredentials = credentials,
                IssuedAt = DateTime.UtcNow
            };
        }



        //CreateRefreshToken
        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
            }
            return Convert.ToBase64String(randomNumber);
        }



        //RefreshAccessTokens
        private ClaimsPrincipal? GetPrincipalFromToken(string token)
        {
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            //todo Handel error
            try
            {
                var claimsPrincipal = jwtSecurityTokenHandler.ValidateToken(token, _tokenValidationParameters, out var validatedToken);

                if (!IsTokenAlgorithmAndTypeMatching(validatedToken))
                {
                    //error
                    return null;
                }
                return claimsPrincipal;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        private bool IsTokenAlgorithmAndTypeMatching(SecurityToken token)
        {
            return (token is JwtSecurityToken jwtSecurityToken) &&
                    jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256Signature,
                    StringComparison.InvariantCultureIgnoreCase);
        }


    }
}


//private string CreateTokenSteps(AppUser user)
//{
//    //1- create list of claims
//    var listClaims = new List<Claim>
//    {
//        new Claim(JwtRegisteredClaimNames.Email, user.Email!),
//        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
//        new Claim("UserID", user.Id.ToString()),
//    };

//    //2- create SigningCredentials object 
//    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret));
//    var key2 = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Secret));
//    var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
//    var signingCredentials2 = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

//    //3- create JwtSecurityToken
//    var jwtSecurityToken = new JwtSecurityToken(
//            claims: listClaims,
//            expires: DateTime.UtcNow.AddMinutes(jwtSettings.DurationInMinutes),
//            signingCredentials: signingCredentials);

//    //3- or create tokenDescriptor
//    var tokenDescriptor = new SecurityTokenDescriptor
//    {
//        Subject = new ClaimsIdentity(listClaims),
//        Expires = DateTime.UtcNow.AddMinutes(jwtSettings.DurationInMinutes),
//        SigningCredentials = signingCredentials,
//        IssuedAt = DateTime.UtcNow
//    };

//    var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

//    //4-create jwtSecurityToken from tokenDescriptor then writeToken to string 
//    var jwtSecurityToken2 = jwtSecurityTokenHandler.CreateToken(tokenDescriptor);
//    var jwtToken2 = jwtSecurityTokenHandler.WriteToken(jwtSecurityToken2);

//    //4-or writeToken to string directly from the jwtSecurityToken object 
//    var jwtToken = jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);

//    return jwtToken;
//}
