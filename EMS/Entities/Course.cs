using System;
using System.Collections.Generic;

#nullable disable

namespace EMS.Entities
{
    public partial class Course
    {
        public Course()
        {
            Terms = new HashSet<Term>();
        }

        public string Name { get; set; }
        public long Code { get; set; }
        public int Id { get; set; }

        public virtual ICollection<Term> Terms { get; set; }
    }
}
