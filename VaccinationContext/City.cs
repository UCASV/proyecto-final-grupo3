using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoVacunacionCovid.VaccinationContext
{
    public partial class City
    {
        public City()
        {
            Cabins = new HashSet<Cabin>();
            Citizens = new HashSet<Citizen>();
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string City1 { get; set; }
        public int IdState { get; set; }

        public virtual State IdStateNavigation { get; set; }
        public virtual ICollection<Cabin> Cabins { get; set; }
        public virtual ICollection<Citizen> Citizens { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
