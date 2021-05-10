using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TopTests.DAL.Entities;
using TopTests.Services.Models.Users;

namespace TopTests.Services.Mapper
{
   public class AuthorizeProfile:Profile
    {
        public AuthorizeProfile()
        {
            CreateMap<Users, RegisterUserDto>();
            CreateMap<Users, UsersDto>();
        }
    }
}
