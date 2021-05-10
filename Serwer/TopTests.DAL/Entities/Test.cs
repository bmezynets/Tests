using System;
using System.Collections.Generic;
using System.Text;

namespace TopTests.DAL.Entities
{
    public class Test
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public TypeOfTest TypeOfTest { get; set; }
        public string AdditionalInfo { get; set; }
        public int TimeOfTest { get; set; }
        public int TeacherId { get; set; }
        public bool AutomaticTime { get; set; }
        public bool isDelete { get; set; }
        public List<FeedBacks> FeedBacks { get; set; }
        public Subjects Subjects { get; set; }
        public Test() { }
        public Test(int subjectId, string additionalinfo,string name,int typeTest,string timeOfTest,int teacherId,bool automatictime)
        {
            AdditionalInfo = additionalinfo;
            SubjectId = subjectId;
            Name = name;
            TypeOfTest = (TypeOfTest)typeTest;
            TimeOfTest = Int32.Parse(timeOfTest);
            TeacherId = teacherId;
            AutomaticTime = automatictime;
        } 
        public Test(int id, string name, List<FeedBacks> feedBacks)
        {
            Id = id;
            Name = name;
            FeedBacks = feedBacks;
        }

    }
}
