using ProyectoVacunacionCovid.VaccinationContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoVacunacionCovid.ViewModels
{
    public static class MapperC
    {
        public static CitizenVm MapCitizenToCitizenVm(Citizen c)
        {
            return new CitizenVm
            {
                Dui = c.Dui,
                Name = c.Name
            };
        }

        public static AppointmentVm MapAppointmentToAppointmentVm(Appointment a)
        {
            return new AppointmentVm
            {
                DateHourProcessed = a.DateHourProcessed,
                DateHourSchedule = a.DateHourSchedule,
                DateHourVaccination = a.DateHourVaccination
            };
        }
        public static CitizenOnQueueVm MapCitizenAppointmentToCitizenOnQ(Citizen c, Appointment a)
        {
            return new CitizenOnQueueVm
            {
                Dui = c.Dui,
                Name = c.Name,
                DateHourProcessed = a.DateHourProcessed,
                DateHourSchedule = a.DateHourSchedule,
                DateHourVaccination = a.DateHourVaccination 
            };
        }
    }
}
