using Domain.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

namespace WebApi.Utils
{
    public static class DIConfigurationExtensions
    {

        public static void AddSwaggerConfigurations(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
                   {
                       var openApiSecurityScheme = new OpenApiSecurityScheme
                       {
                           In = ParameterLocation.Header,
                           Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                           Name = "Authorization",
                           Type = SecuritySchemeType.Http,
                           BearerFormat = "JWT",
                           Scheme = JwtBearerDefaults.AuthenticationScheme,
                           Reference = new OpenApiReference
                           {
                               Type = ReferenceType.SecurityScheme,
                               Id = JwtBearerDefaults.AuthenticationScheme
                           }
                       };

                       options.AddSecurityDefinition("Bearer", openApiSecurityScheme);

                       options.AddSecurityRequirement(new OpenApiSecurityRequirement
                       {
                           { openApiSecurityScheme, new [] { JwtBearerDefaults.AuthenticationScheme } }
                       });
                   }
                   );
        }

        public static void AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = new JwtSettings();
            configuration.Bind(nameof(jwtSettings), jwtSettings);
            services.AddSingleton(jwtSettings);

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret)),
                ValidateIssuer = false,
                ValidateAudience = false,
                RequireExpirationTime = true,
            };

            services.AddSingleton(tokenValidationParameters);

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = tokenValidationParameters;
            });
        }
    }
}
