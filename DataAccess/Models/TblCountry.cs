using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class TblCountry
    {
        public TblCountry()
        {
            TblStates = new HashSet<TblState>();
        }

        public int Id { get; set; }
        public string Sortname { get; set; } = null!;
        public string Name { get; set; } = null!;

        public virtual ICollection<TblState> TblStates { get; set; }
    }
}
