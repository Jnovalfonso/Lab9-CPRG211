using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLab
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public int Credit { get; set; }

        public Course(int courseId, string name, int credit)
        {
            CourseId = courseId;
            Name = name;
            Credit = credit;
        }
    }
}
