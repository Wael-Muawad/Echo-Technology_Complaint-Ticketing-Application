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
            CreateMap<UserCreateDto, User>();
            CreateMap<UserUpdateDto, User>();
            CreateMap<UserReadDto, User>();

            CreateMap<User, UserCreateDto>();
            CreateMap<User, UserUpdateDto>();
            CreateMap<User, UserReadDto>();
        }
    }
}
