using System;
using System.Collections.Generic;

namespace Labb4v2.Models
{
    public partial class RoleList
    {
        public RoleList()
        {
            Personels = new HashSet<Personel>();
        }

        public int RoleId { get; set; }
        public string WorkRole { get; set; }

        public virtual ICollection<Personel> Personels { get; set; }
    }
}
