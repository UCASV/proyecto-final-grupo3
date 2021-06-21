using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoVacunacionCovid.VaccinationContext
{
    public partial class ManagerxCabin
    {
        public int IdManager { get; set; }
        public int IdCabin { get; set; }

        public virtual Cabin IdCabinNavigation { get; set; }
        public virtual Manager IdManagerNavigation { get; set; }
    }
}
