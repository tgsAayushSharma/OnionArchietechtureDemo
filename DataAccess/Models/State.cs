using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class State
    {
        public State()
        {
            Employees = new HashSet<Employee>();
            TblCities = new HashSet<City>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int CountryId { get; set; }

        public virtual Country Country { get; set; } = null!;
        public virtual ICollection<City> TblCities { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }



    }
}
