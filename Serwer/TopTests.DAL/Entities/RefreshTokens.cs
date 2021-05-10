﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TopTests.DAL.Entities
{
    public class RefreshTokens : BaseEntity
    {
        public int Id { get; set; }
        public string Refresh { get; set; }
        public int UserId { get; set; }
        public DateTime DateOfStart { get; set; }
        public DateTime DateOfEnd { get; set; }
        public Users User { get; set; }
        public bool IsValid { get; set; }
        public RefreshTokens() { }
        public RefreshTokens(string refresh, int userId, bool isvalid)
        {
            Refresh = refresh;
            UserId = userId;
            DateOfStart = DateTime.Now;
            DateOfEnd = DateTime.Now.AddDays(100);
            IsValid = isvalid;
        }
        public void Delete(bool isvalid)
        {
            IsValid = isvalid;
        }
    }
}
