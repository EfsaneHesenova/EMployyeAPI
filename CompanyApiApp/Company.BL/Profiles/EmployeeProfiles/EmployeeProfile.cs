using AutoMapper;
using Company.BL.DTOs.EmployeeDtos;
using Company.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.BL.Profiles.EmployeeProfiles
{
    public class EmployeeProfile: Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeCreateDto, Employee>();
            CreateMap<EmployeeCreateDto, Employee>().ReverseMap();
        }
    }
}
