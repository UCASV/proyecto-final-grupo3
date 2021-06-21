using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoVacunacionCovid.VaccinationContext
{
    public partial class ChronicleDisease
    {
        public ChronicleDisease()
        {
            UserDiseases = new HashSet<UserDisease>();
        }

        public int Id { get; set; }
        public string ChronicleDisease1 { get; set; }

        public virtual ICollection<UserDisease> UserDiseases { get; set; }
    }
}
