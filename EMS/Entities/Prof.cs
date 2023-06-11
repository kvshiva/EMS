using System;
using System.Collections.Generic;

#nullable disable

namespace EMS.Entities
{
    public partial class Prof
    {
        public Prof()
        {
            Terms = new HashSet<Term>();
        }

        public string Name { get; set; }
        public long Code { get; set; }
        public int Id { get; set; }

        public virtual ICollection<Term> Terms { get; set; }
    }
}
