using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoVacunacionCovid.VaccinationContext
{
    public partial class UserDisease
    {
        public int IdChronicleDisease { get; set; }
        public int DuiCitizen { get; set; }

        public virtual Citizen DuiCitizenNavigation { get; set; }
        public virtual ChronicleDisease IdChronicleDiseaseNavigation { get; set; }
    }
}
