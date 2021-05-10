using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace TopTests.DAL.Entities
{
   public class Users:BaseEntity
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
        public Users(string firstName, string lastName, string email,string hash,string salt,RoleOfUser roleOfUser)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            HashPassword = hash;
            Salt = salt;
            DateCreated = DateTime.Now;
            RoleOfUser = roleOfUser;
            StatusOfVerification = "Processing";
            CodeOfVerification = GetRandomString(256);
        }

        public Users()
        {
        }
       public string GetRandomString(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            string code = "";
            using (RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider())
            {
                while (code.Length != length)
                {
                    byte[] oneByte = new byte[1];
                    provider.GetBytes(oneByte);
                    char character = (char)oneByte[0];
                    if (valid.Contains(character))
                    {
                        code += character;
                    }
                }
            }
            return code;
        }
    }
}
