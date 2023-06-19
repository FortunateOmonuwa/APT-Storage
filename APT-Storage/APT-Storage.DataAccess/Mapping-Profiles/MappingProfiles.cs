using APT_Storage.DataAccess.DTOs;
using APT_Storage.Domain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APT_Storage.DataAccess.Mapping_Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<UserCreateDTO, User>().ReverseMap();
            CreateMap<User, UserGetDTO>().ReverseMap();
            
        }
    }
}
