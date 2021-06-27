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
using ProyectoVacunacionCovid.Models;
using ProyectoVacunacionCovid.View;

namespace ProyectoVacunacionCovid
{
    public partial class AppointmentFollowUpSE : Form
    {
        public frmVaccinationProcess VaccinationProcess { get; set; }
        public AppointmentFollowUpSE()
        {
            InitializeComponent();
            VaccinationProcess = new frmVaccinationProcess();
            
        }

        //inicializando lista de cola de espera
        static public List<Citizen> CitizensQueueList;
        static public void InstanceQueue()
        {
            CitizensQueueList = new List<Citizen>();
        }

        private void btnBuscarSeguimiento_Click(object sender, EventArgs e)
        {

            var db = new Proyecto_VacunacionContext();

            List<Citizen> residents = db.Citizens.ToList();
            List<Appointment> appointmentsList = db.Appointments.ToList();


            try
            {
                int dui = int.Parse(txtBuscarSeguimiento.Text);

                bool found = residents
                    .Where(r => r.Dui == dui)
                    .ToList().Count() > 0;

                /*bool hasAppt = appointmentsList
                    .Where(appt => appt.DuiCitizen == dui)
                    .ToList().Count() > 0;*/



                if (found)
                {

                    MessageBox.Show("¡El ciudadano es elegble, bienvenido!", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tabSeguimientoCitas.SelectedIndex = 1;

                }
                else // if (found && hasAppt == false)
                {
                    if (MessageBox.Show("¡Ciudadano no registrado! ¿Desea registrar?", "Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        var apptRegistry = new Proyecto.RegistroCita();
                        apptRegistry.Show();
                    }
                }
                //else 
                   //  MessageBox.Show("¡Usuario no encontrado! ¿Desea registrarlo?" , "Registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            catch(FormatException)
            {
                MessageBox.Show("Ingrese un numero de DUI valido", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

         }

        private void AppointmentFollowUpSE_Load_1(object sender, EventArgs e)
        {
            tabSeguimientoCitas.ItemSize = new Size(0, 1);

            tabSeguimientoCitas.SizeMode = TabSizeMode.Fixed;
            tabSeguimientoCitas.TabStop = false;
            ControlBox = true;
            
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnProcesoVacunacion_Click(object sender, EventArgs e)
        {
            VaccinationProcess.Show();            
        }

        private void btnProcesoVacunacion2_Click(object sender, EventArgs e)
        {
            VaccinationProcess.Show();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            tabSeguimientoCitas.SelectedIndex = 0;
            txtBuscarSeguimiento.Text = null;
        }
    }
}
