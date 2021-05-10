using System;
using System.Collections.Generic;
using System.Text;

namespace TopTests.Services.Models.Users
{
   public class RegisterUserDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string CodeOfVerification { get; set; }
        public string RoleOfUser { get; set; }
    }
}
