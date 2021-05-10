using System;
using System.Collections.Generic;
using System.Text;
using TopTests.DAL.Entities;

namespace TopTests.Services.Models.Users
{
   public class UsersDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string HashPassword { get; set; }
        public string Salt { get; set; }
        public string StatusOfVerification { get; set; }
        public RoleOfUser RoleOfUser { get; set; }
        public string CodeOfVerification { get; set; }
        public bool IsDeleted { get; set; }
        public List<RefreshTokens> RefreshTokens { get; set; }
    }
}
