
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
using ProyectoVacunacionCovid.ViewModels;

namespace ProyectoVacunacionCovid
{
    public partial class AppointmentFollowUpSE : Form
    {
     
        public frmVaccinationProcess VaccinationProcess { get; set; }
        static public List<Citizen> CitizensQueueList;

        public AppointmentFollowUpSE()
        {
            InitializeComponent();
            VaccinationProcess = new frmVaccinationProcess();
            
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

               

                bool eligible = appointmentsList
                    .Where(appt => appt.DuiCitizen == dui)
                    .ToList().Count() <= 2;



                if (found)
                {

                    MessageBox.Show("¡El ciudadano es elegible, bienvenido!", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var ciudadano = db.Citizens.FirstOrDefault(c => c.Dui == dui);
                    var ins = db.Institutions.FirstOrDefault(i => i.Id == ciudadano.IdInstitution); //accediendo a la institucion que esta linkeada al dui consultado
                    var dir = db.Addresses.FirstOrDefault(a => a.Id == ciudadano.IdAddress); //accediendo a la direccion que esta linkeada al dui consultado
                    var appt = db.Appointments.FirstOrDefault(p => p.DuiCitizen == ciudadano.Dui);
                    //CitizenWaitingQueue.AddCitizenOnQueue(ciudadano);
                    
                    tabSeguimientoCitas.SelectedIndex = 1;

                    lblDui.Text = Convert.ToString(ciudadano.Dui);
                    lblNombre.Text = ciudadano.Name;
                    lblContacto.Text = ciudadano.PhoneNumber;
                    lblEmail.Text = ciudadano.Email;
                    lblDOB.Text = Convert.ToString(ciudadano.DateOfBirth);
                    lblAddress.Text = dir.Location;
                    lblInstitution.Text = ins.Institution1;

                    var appointmentsListVm = new List<AppointmentVm>();

                    appointmentsList.ForEach(a => appointmentsListVm.Add(MapperC.MapAppointmentToAppointmentVm(a)));


                    dgvAppts.DataSource = appointmentsListVm.Where(ap => ap.DuiCitizen == dui).ToList();
                    dgvAppts.Columns[0].HeaderText = "DUI";
                    dgvAppts.Columns[0].HeaderText = "Fecha programada";
                    dgvAppts.Columns[0].HeaderText = "Fecha/hora vacunacion";
                    dgvAppts.Columns[0].HeaderText = "Fecha/hora Proceso completado";

                    // no funciona ---> dgvAppts.Columns["date_hour_schedule"].DataPropertyName = "DateHourSchedule";

                }
                else // if (found && hasAppt == false)
                {
                    if (MessageBox.Show("¡Ciudadano no registrado! ¿Desea registrar?", "Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        var apptRegistry = new Proyecto.RegistroCita(new Cabin() {Id=1});
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

            CitizenWaitingQueue.InstanceQueue();

           

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
            btnProcessCitizen.Enabled = true;
        }

        private void btnProcessCitizen_Click(object sender, EventArgs e)
        {
            var db = new Proyecto_VacunacionContext();
            int dui = int.Parse(txtBuscarSeguimiento.Text);
            List<Appointment> appointmentsList = db.Appointments.ToList();
            bool eligible = appointmentsList
                    .Where(appt => appt.DuiCitizen == dui)
                    .ToList().Count() <= 2;

            bool flag = Models.CitizenWaitingQueue.CitizensList.Exists(c => c.Dui== dui);
            bool appointmentAviable = appointmentsList.Exists(c => c.DuiCitizen == dui && c.DateHourVaccination == null);


            if (eligible && !(flag) && appointmentAviable) 
            {
                var ciudadano = db.Citizens.FirstOrDefault(c => c.Dui == dui);
                CitizenWaitingQueue.AddCitizenOnQueue(ciudadano);
                btnProcessCitizen.Enabled = false;
            }
            else
                MessageBox.Show($"La persona con numero de DUI {dui} ya posee la dos dosis de la vacuna o se encuentra en proceso", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
