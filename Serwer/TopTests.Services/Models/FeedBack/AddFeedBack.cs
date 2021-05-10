using System;
using System.Collections.Generic;
using System.Text;

namespace TopTests.Services.Models.FeedBack
{
   public class AddFeedBack
    {
        public string TestId { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; }
        public string Name { get; set; }
    }
}
