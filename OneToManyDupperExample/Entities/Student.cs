using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToManyDupperExample.Entities
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public int Age { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }

        

    }
}
