using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoVacunacionCovid.ViewModels
{
    public class CitizenOnQueueVm
    {
        public int Dui { get; set; }
        public string Name { get; set; }
        public DateTime? DateHourSchedule { get; set; }
        public DateTime? DateHourVaccination { get; set; }
        public DateTime? DateHourProcessed { get; set; }
    }
}
