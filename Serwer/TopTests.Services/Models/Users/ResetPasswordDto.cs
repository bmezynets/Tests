using System;
using System.Collections.Generic;
using System.Text;

namespace TopTests.Services.Models.Users
{
    public class ResetPasswordDto
    {
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
