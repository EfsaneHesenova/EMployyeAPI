using AutoMapper;
using Company.BL.DTOs.DepartmentDtos;
using Company.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.BL.Profiles.DepartmentProfiles
{
    public class DepartmentProfile: Profile
    {
        public DepartmentProfile()
        {
            CreateMap<DepartmentCreateDto, Department>();
            CreateMap<DepartmentCreateDto, Department>().ReverseMap();
            CreateMap<DepartmentUpdateDto, Department>();
            CreateMap<DepartmentUpdateDto, Department>().ReverseMap();


        }
    }
}
