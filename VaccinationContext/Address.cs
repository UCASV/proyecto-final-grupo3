using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoVacunacionCovid.VaccinationContext
{
    public partial class Address
    {
        public Address()
        {
            Cabins = new HashSet<Cabin>();
            Citizens = new HashSet<Citizen>();
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Location { get; set; }
        public int IdCity { get; set; }

        public virtual City IdCityNavigation { get; set; }
        public virtual ICollection<Cabin> Cabins { get; set; }
        public virtual ICollection<Citizen> Citizens { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
