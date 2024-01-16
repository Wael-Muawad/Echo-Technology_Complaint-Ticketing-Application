using AutoMapper;
using Domain.ApiDTO.Users;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AutoMapperProfiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<UserCreateDto, AppUser>();
            CreateMap<UserUpdateDto, AppUser>();
            CreateMap<UserReadDto, AppUser>();

            CreateMap<AppUser, UserCreateDto>();
            CreateMap<AppUser, UserUpdateDto>();
            CreateMap<AppUser, UserReadDto>();
        }
    }
}
