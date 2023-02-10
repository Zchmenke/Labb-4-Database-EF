using System;
using System.Collections.Generic;

namespace Labb4v2.Models
{
    public partial class StudentCourse
    {
        public int ListId { get; set; }
        public int StudentId { get; set; }
        public int? CourseId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
}
