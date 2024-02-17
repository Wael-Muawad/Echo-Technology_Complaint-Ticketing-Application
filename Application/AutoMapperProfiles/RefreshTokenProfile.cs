using AutoMapper;
using Domain.ApiDTO.RefreshTokens;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AutoMapperProfiles
{
    public class RefreshTokenProfile : Profile
    {
        public RefreshTokenProfile()
        {
            CreateMap<RefreshTokenCreateDto, RefreshToken>();
            CreateMap<RefreshTokenUpdateDto, RefreshToken>();
            CreateMap<RefreshTokenReadDto, RefreshToken>();

            CreateMap<RefreshToken, RefreshTokenCreateDto>();
            CreateMap<RefreshToken, RefreshTokenUpdateDto>();
            CreateMap<RefreshToken, RefreshTokenReadDto>();
        }
    }
}
