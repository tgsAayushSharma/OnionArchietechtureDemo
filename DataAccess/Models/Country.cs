using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Country
    {
        public Country()
        {
            TblStates = new HashSet<State>();
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Sortname { get; set; } = null!;
        public string Name { get; set; } = null!;

        public virtual ICollection<State> TblStates { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
