using AutoMapper;
using Company.BL.DTOs.AppUserDtos;
using Company.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.BL.Profiles.AppUserProfiles
{
    public class AppUserProfile: Profile
    {
        public AppUserProfile()
        {      
            CreateMap<LoginDto, AppUser>().ReverseMap();


            CreateMap<RegisterDto, AppUser>().ReverseMap()
                .ForMember(prop => prop.Password, opt => opt.Ignore())
                .ForMember(prop => prop.CheckPassword, opt => opt.Ignore());

            CreateMap<AppUserReadDto, AppUser>().ReverseMap();

        }
    }
}
