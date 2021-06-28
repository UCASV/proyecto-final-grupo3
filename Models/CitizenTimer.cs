using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoVacunacionCovid.Models
{
    public class CitizenTimer
    {
        public int Dui { get; set; }
        public string Name { get; set; }
        public int TimeSec { get; set; }
        public int TimeMinutes { get { return TimeSec/60 ; }}
    }
}
