using ProyectoVacunacionCovid.Entities;
using ProyectoVacunacionCovid.VaccinationContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoVacunacionCovid.ViewModels
{
    public static class Mapper
    {
        static CitizenVm MapCitizenToCitizenVm(Citizen c)
        {
            return new CitizenVm
            {
                Dui = c.Dui,
                Name = c.Name
            };
        }

        static AppointmentVm MapAppointmentToAppointmentVm(Appointment a)
        {
            return new AppointmentVm
            {
                DateHourProcessed = a.DateHourProcessed,
                DateHourSchedule = a.DateHourSchedule,
                DateHourVaccination = a.DateHourVaccination
            };
        }
        static WaitingCitizen MapCitizenToWaitingCitizen(Citizen c)
        {
            return new WaitingCitizen()
            {
                Dui = c.Dui,
                Name = c.Name
            };
        }
    }
}
