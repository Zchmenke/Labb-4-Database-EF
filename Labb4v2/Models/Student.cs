using System;
using System.Collections.Generic;

namespace Labb4v2.Models
{
    public partial class Student
    {
        public Student()
        {
            Grades = new HashSet<Grade>();
            StudentCourses = new HashSet<StudentCourse>();
        }

        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalNumber { get; set; }
        public int? ClassIdstudent { get; set; }

        public virtual Class ClassIdstudentNavigation { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
