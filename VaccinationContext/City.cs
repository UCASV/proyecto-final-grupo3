using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoVacunacionCovid.VaccinationContext
{
    public partial class City
    {
        public City()
        {
            Addresses = new HashSet<Address>();
        }

        public int Id { get; set; }
        public string City1 { get; set; }
        public int IdState { get; set; }

        public virtual State IdStateNavigation { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
