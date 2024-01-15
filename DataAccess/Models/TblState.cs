using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class TblState
    {
        public TblState()
        {
            Employees = new HashSet<Employee>();
            TblCities = new HashSet<TblCity>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int CountryId { get; set; }

        public virtual TblCountry Country { get; set; } = null!;
        public virtual ICollection<TblCity> TblCities { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }



    }
}
