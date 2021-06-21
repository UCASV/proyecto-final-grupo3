using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoVacunacionCovid.VaccinationContext
{
    public partial class UserDisease
    {
        public int IdChronicleDisease { get; set; }
        public int IdCitizen { get; set; }

        public virtual ChronicleDisease IdChronicleDiseaseNavigation { get; set; }
        public virtual Citizen IdCitizenNavigation { get; set; }
    }
}
