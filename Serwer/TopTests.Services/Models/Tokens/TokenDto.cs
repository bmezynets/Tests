using System;
using System.Collections.Generic;
using System.Text;

namespace TopTests.Services.Models.Tokens
{
    public class TokenDto
    {
        public string Name { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public int Code { get; set; }
    }
}
