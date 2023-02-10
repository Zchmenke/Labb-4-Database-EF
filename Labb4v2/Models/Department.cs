using System;
using System.Collections.Generic;

namespace Labb4v2.Models
{
    public partial class Department
    {
        public Department()
        {
            Personels = new HashSet<Personel>();
        }

        public int DepId { get; set; }
        public string Depname { get; set; }

        public virtual ICollection<Personel> Personels { get; set; }
    }
}
