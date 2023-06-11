using System;
using System.Collections.Generic;

#nullable disable

namespace EMS.Entities
{
    public partial class Student
    {
        public Student()
        {
            Selections = new HashSet<Selection>();
        }

        public string Name { get; set; }
        public long Code { get; set; }
        public int Id { get; set; }
        public double? Average { get; set; }

        public virtual ICollection<Selection> Selections { get; set; }
    }
}
