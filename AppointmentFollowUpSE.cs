using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoVacunacionCovid.VaccinationContext;

namespace ProyectoVacunacionCovid
{
    public partial class AppointmentFollowUpSE : Form
    {
        public AppointmentFollowUpSE()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AppointmentFollowUpSE_Load(object sender, EventArgs e)
        {

        }

        private void txtBuscarSeguimiento_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscarSeguimiento_Click(object sender, EventArgs e)
        {
            var db = new Proyecto_VacunacionContext();

            List<Citizen> residents = db.Citizens.ToList();

            int dui = int.Parse(txtBuscarSeguimiento.Text);

            bool found = residents
                .Where(r => r.Dui == dui)
                .ToList().Count() > 0;

            if(found)
            {
                MessageBox.Show("¡Bienvenido!", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("¡Usuario no encontrado!", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);


        }
    }
}
