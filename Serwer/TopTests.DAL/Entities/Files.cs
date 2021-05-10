using System;
using System.Collections.Generic;
using System.Text;

namespace TopTests.DAL.Entities
{
    public class Files
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public Byte[] FileContent { get; set; }
        public int TypeOfTest { get; set; }
        public Files() { }
        public Files(int Id, string FileName, Byte[] FileContent,int TypeOfTest)
        {
            this.Id = Id;
            this.FileName = FileName;
            this.FileContent = FileContent;
            this.TypeOfTest = TypeOfTest;
        }
    }
}
