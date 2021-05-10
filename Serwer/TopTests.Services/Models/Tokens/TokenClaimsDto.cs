using System;
using System.Collections.Generic;
using System.Text;

namespace TopTests.Services.Models.Tokens
{
    public class TokenClaimsDto
    {
        public bool CheckRefreshToken { get; set; }
        public int Id { get; set; }
        public int UserId { get; set; }
    }
}
