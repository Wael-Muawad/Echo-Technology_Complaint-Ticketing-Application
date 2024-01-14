using AutoMapper;
using Domain.ApiDTO.Complaints;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AutoMapperProfiles
{
    public class ComplaintsProfile : Profile
    {
        public ComplaintsProfile()
        {
            CreateMap<ComplaintCreateDto, Complaint>();
            CreateMap<ComplaintUpdateDto, Complaint>();
            CreateMap<ComplaintReadDto, Complaint>();

            CreateMap<Complaint, ComplaintCreateDto>();
            CreateMap<Complaint, ComplaintUpdateDto>();
            CreateMap<Complaint, ComplaintReadDto>();
        }
    }
}
