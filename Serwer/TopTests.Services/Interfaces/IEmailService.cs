using System;
using System.Collections.Generic;
using System.Text;
using TopTests.Services.Models.Users;

namespace TopTests.Services.Interfaces
{
   public interface IEmailService 
    { 
        bool EmailAfterRegistration(RegisterUserDto registerUserDto);
        bool ResetPassword(string code,string email);

    }
}
