using System;
using System.Collections.Generic;
using System.Dynamic;

namespace Library.Convos.Models 
{
    public class Course
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Person> Roster { get; set; }
        public List<Assignment> Assignments { get; set; }
        public List<Module> Modules { get; set; }

        public Course() 
        {
            Roster = new List<Person>();
            Assignments = new List<Assignment>();
            Modules = new List<Module>();
            Name = string.Empty;
            Description = string.Empty;
            Code = string.Empty;
        }

        public override string ToString()
        {
            return $"[{Code}] - {Name}";
        }
    }
}