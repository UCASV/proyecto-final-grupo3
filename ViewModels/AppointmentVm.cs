using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoVacunacionCovid.ViewModels
{
    public class AppointmentVm
    {
        public DateTime? DateHourSchedule { get; set; }
        public DateTime? DateHourVaccination { get; set; }
        public DateTime? DateHourProcessed { get; set; }
    }
}
