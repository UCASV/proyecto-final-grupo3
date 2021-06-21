using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoVacunacionCovid.VaccinationContext
{
    public partial class SecundaryEffect
    {
        public SecundaryEffect()
        {
            AppointmentEffects = new HashSet<AppointmentEffect>();
        }

        public int Id { get; set; }
        public string SecundaryEffect1 { get; set; }

        public virtual ICollection<AppointmentEffect> AppointmentEffects { get; set; }
    }
}
