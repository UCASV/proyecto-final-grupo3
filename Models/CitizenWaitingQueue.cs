using ProyectoVacunacionCovid.VaccinationContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoVacunacionCovid.Models
{
    public static class CitizenWaitingQueue
    {

        static public List<Citizen> CitizensList;
        static void InstanceQueue()
        {
            CitizensList = new List<Citizen>();
        }

        static public void AddCitizenOnQueue(Citizen c)
        {
            CitizensList.Add(c);
        }

        static public void RemoveCitizenOnQueue(Citizen c)
        {
            CitizensList.Remove(c);
        }
    }
}
