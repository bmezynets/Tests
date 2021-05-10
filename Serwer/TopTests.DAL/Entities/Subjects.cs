using System;
using System.Collections.Generic;
using System.Text;

namespace TopTests.DAL.Entities
{
    public class Subjects
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TeacherId { get; set; }
        public bool isDelete { get; set; }
        public List<Test> Tests { get; set; } = new List<Test>();
        public Subjects()
        {

        }
        public Subjects(int teacherId,string name)
        {
            Name = name;
            TeacherId = teacherId;
        }
        public Subjects(int id,string name,List<Test> test)
        {
            Id = id;
            Name = name;
            Tests = test;
        }
    }
}
