using System;
using System.Collections.Generic;

#nullable disable

namespace EMS.Entities
{
    public partial class Selection
    {
        public int Sid { get; set; }
        public int Tid { get; set; }
        public int Id { get; set; }

        public virtual Student SidNavigation { get; set; }
        public virtual Term TidNavigation { get; set; }
    }
}
