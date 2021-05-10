using System;
using System.Collections.Generic;
using System.Text;

namespace TopTests.DAL.Entities
{
    public class News: BaseEntity
    {
        public int Id { get; set; }
        public string TopicOfNews { get; set; }
        public string Information { get; set; }
    }
}
