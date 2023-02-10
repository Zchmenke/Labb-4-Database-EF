using System;
using System.Collections.Generic;

namespace Labb4v2.Models
{
    public partial class Personel
    {
        public Personel()
        {
            Courses = new HashSet<Course>();
            Grades = new HashSet<Grade>();
        }

        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public int EmployeeRole { get; set; }
        public decimal MonthlySalary { get; set; }
        public int YearsEmployed { get; set; }
        public int? DepId { get; set; }

        public virtual Department Dep { get; set; }
        public virtual RoleList EmployeeRoleNavigation { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
    }
}
