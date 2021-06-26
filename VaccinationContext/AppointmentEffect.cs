using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoVacunacionCovid.VaccinationContext
{
    public partial class AppointmentEffect
    {
        public int Id { get; set; }
        public int? Minute { get; set; }
        public int IdSecundaryEffect { get; set; }
        public int IdAppointment { get; set; }

        public virtual Appointment IdAppointmentNavigation { get; set; }
        public virtual SecundaryEffect IdSecundaryEffectNavigation { get; set; }
    }
}
