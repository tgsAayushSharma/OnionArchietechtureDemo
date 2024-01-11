using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class TblCity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int StateId { get; set; }

        public virtual TblState State { get; set; } = null!;
    }
}
