using System;
using System.Collections.Generic;

#nullable disable

namespace EMS.Entities
{
    public partial class Term
    {
        public Term()
        {
            Selections = new HashSet<Selection>();
        }

        public int Id { get; set; }
        public int Sem { get; set; }
        public int Pid { get; set; }
        public int Cid { get; set; }

        public virtual Course CidNavigation { get; set; }
        public virtual Prof PidNavigation { get; set; }
        public virtual ICollection<Selection> Selections { get; set; }
    }
}
