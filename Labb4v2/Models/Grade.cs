using System;
using System.Collections.Generic;

namespace Labb4v2.Models
{
    public partial class Grade
    {
        public int? StudentIdgrade { get; set; }
        public string GradeSub { get; set; }
        public int GradingTeacher { get; set; }
        public DateTime Gradedate { get; set; }
        public int Grade1 { get; set; }
        public int GradeId { get; set; }

        public virtual Personel GradingTeacherNavigation { get; set; }
        public virtual Student StudentIdgradeNavigation { get; set; }
    }
}
