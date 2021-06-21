using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoVacunacionCovid.VaccinationContext
{
    public partial class Manager
    {
        public Manager()
        {
            Cabins = new HashSet<Cabin>();
            ManagerxCabins = new HashSet<ManagerxCabin>();
        }

        public int Id { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public int IdEmployee { get; set; }

        public virtual Employee IdEmployeeNavigation { get; set; }
        public virtual ICollection<Cabin> Cabins { get; set; }
        public virtual ICollection<ManagerxCabin> ManagerxCabins { get; set; }
    }
}
