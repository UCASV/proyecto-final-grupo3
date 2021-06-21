using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoVacunacionCovid.VaccinationContext
{
    public partial class Employee
    {
        public Employee()
        {
            Managers = new HashSet<Manager>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string TypeEmployee { get; set; }
        public int IdAddress { get; set; }

        public virtual Address IdAddressNavigation { get; set; }
        public virtual ICollection<Manager> Managers { get; set; }
    }
}
