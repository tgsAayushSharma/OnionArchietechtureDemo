using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class City
    {
        public City()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int StateId { get; set; }

        public virtual State State { get; set; } = null!;
        public virtual ICollection<Employee> Employees { get; set; }

    }
}
