using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoVacunacionCovid.VaccinationContext
{
    public partial class Appointment
    {
        public Appointment()
        {
            AppointmentEffects = new HashSet<AppointmentEffect>();
        }

        public int Id { get; set; }
        public DateTime? DateHourSchedule { get; set; }
        public DateTime? DateHourVaccination { get; set; }
        public DateTime? DateHourProcessed { get; set; }
        public int IdCabin { get; set; }
        public int DuiCitizen { get; set; }

        public virtual Citizen DuiCitizenNavigation { get; set; }
        public virtual Cabin IdCabinNavigation { get; set; }
        public virtual ICollection<AppointmentEffect> AppointmentEffects { get; set; }
    }
}
