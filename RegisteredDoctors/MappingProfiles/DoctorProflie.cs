using AutoMapper;
using RegisteredDoctors.Data.Dtos;
using RegisteredDoctors.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisteredDoctors.MappingProfile
{
    public class DoctorProflie : Profile
    {
        public DoctorProflie()
        {
            CreateMap<RegisteredDoctor, DoctorToReturnDTO>().ReverseMap();
        }
    }
}
