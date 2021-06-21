using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoVacunacionCovid.VaccinationContext
{
    public partial class Citizen
    {
        public Citizen()
        {
            Appointments = new HashSet<Appointment>();
            UserDiseases = new HashSet<UserDisease>();
        }

        public int Dui { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int IdCity { get; set; }
        public int IdInstitution { get; set; }

        public virtual City IdCityNavigation { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<UserDisease> UserDiseases { get; set; }
    }
}
