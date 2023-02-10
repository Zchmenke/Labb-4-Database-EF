using System;
using System.Collections.Generic;

namespace Labb4v2.Models
{
    public partial class Course
    {
        public Course()
        {
            StudentCourses = new HashSet<StudentCourse>();
        }

        public int CourseId { get; set; }
        public string Subject { get; set; }
        public int? HeadTeacherId { get; set; }
        public bool? IsActive { get; set; }

        public virtual Personel HeadTeacher { get; set; }
        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
