using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Domain.Entities.Users;
using WebApp.Service.DTOs.Users;

namespace WebApp.Service.Mappers
{
    public class MappingProfile:Profile
    {
        public MappingProfile() 
        {
            CreateMap<User,UserForChangePasswordDTO>().ReverseMap();
            CreateMap<User, UserForCreationDTO>().ReverseMap();
            CreateMap<User, UserForUpdateDTO>().ReverseMap();
            CreateMap<User, UserForViewDTO>().ReverseMap();
            CreateMap<User, UserForLoginDTO>().ReverseMap();
        }
    }
}
