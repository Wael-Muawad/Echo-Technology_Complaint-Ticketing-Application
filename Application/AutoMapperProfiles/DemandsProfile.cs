using AutoMapper;
using Domain.ApiDTO.Demands;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AutoMapperProfiles
{
    public class DemandsProfile : Profile
    {
        public DemandsProfile()
        {
            CreateMap<DemandCreateDto, Demand>();
            CreateMap<DemandUpdateDto, Demand>();
            CreateMap<DemandReadDto, Demand>();

            CreateMap<Demand, DemandCreateDto>();
            CreateMap<Demand, DemandUpdateDto>();
            CreateMap<Demand, DemandReadDto>();
        }
    }
}
