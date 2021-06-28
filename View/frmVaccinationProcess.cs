using Microsoft.EntityFrameworkCore;
using ProyectoVacunacionCovid.Models;
using ProyectoVacunacionCovid.Properties;
using ProyectoVacunacionCovid.VaccinationContext;
using ProyectoVacunacionCovid.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoVacunacionCovid.View
{
    public partial class frmVaccinationProcess : Form
    {

        public List<CitizenVm> CitizenQueueVm { get; set; }
        public List<CitizenVm> CitizenOnObservation { get; set; }
        public List<CitizenTimer> CitizenTimerCounter { get; set; }
        public List<Citizen> CitizenQueue { get; set; }
        public frmVaccinationProcess()
        {
            InitializeComponent();
            CitizenQueueVm = new List<CitizenVm>();
            CitizenOnObservation = new List<CitizenVm>();
            CitizenTimerCounter = new List<CitizenTimer>();
            CitizenQueue = new List<Citizen>();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        
        private void frmVaccinationProcess_Load(object sender, EventArgs e)
        {
            waitingTimer.Enabled = true;
            //hiding tabsHeaders on tabControl
            tabMain.ItemSize = new Size(0, 1);
            tabMain.SizeMode = TabSizeMode.Fixed;
            tabMain.TabStop = false;

            //Evita errores de generacion de datagridview
            tabPage2.BringToFront();
            tabPage2.Show();
            tabPage1.BringToFront();
            tabPage1.Show();

            LoadData();
        }
        private void LoadData()
        {
            var SecundaryEffectsList = new List<SecundaryEffect>();
            
            //dgv Datasource           
            using (var db = new Proyecto_VacunacionContext())
            {
                try
                {                    
                    SecundaryEffectsList = db.SecundaryEffects.ToList();
                }
                catch (Exception)
                {
                    MessageBox.Show("Error en base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }
                    
            }
            //Following methon causes exception on indexrow
            //UpdateDgvWaitingQueue();
            //Loading SecundaryEffects on cmb
            //loading data on comboBox
            cmbSecundaryEffects.DataSource = SecundaryEffectsList;
            cmbSecundaryEffects.DisplayMember = "SecundaryEffect1";
            cmbSecundaryEffects.ValueMember = "Id";
            cmbSecundaryEffects.Text = "-Seleccionar-";


        }
        private void waitingTimer_Tick(object sender, EventArgs e)
        {
            lblTimer.Text = DateTime.Now.ToString("hh:mm tt");
            AddTimeToCitizens();
        }

        private void btnWaitingQueue_Click(object sender, EventArgs e)
        {
            tabPage1.BringToFront();
            tabPage1.Show();
            //Animacion tabControl
            panelAnimation.Width = btnWaitingQueue.Width;
            panelAnimation.Left = btnWaitingQueue.Left;
        }

        private void btnObservation_Click(object sender, EventArgs e)
        {
            tabPage2.BringToFront();
            tabPage2.Show();

            panelAnimation.Width = btnObservation.Width;
            panelAnimation.Left = btnObservation.Left;
        }

        private void dgvWaitingCitizen_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if((e.RowIndex != -1) && (e.ColumnIndex == 2))
            {
                if (dgvWaitingCitizen.CurrentRow == null) return;

                if (MessageBox.Show("Aplicar vacuna a paciente?", "Vacunar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //var slect = dgvWaitingCitizen.CurrentRow.DataBoundItem as CitizenVm;
                    CitizenVm selectedItem = dgvWaitingCitizen.SelectedRows[0].DataBoundItem as CitizenVm;

                    //Null el dataSource por excepcion de columnase seleccionadas
                    dgvWaitingCitizen.DataSource = null;

                    CitizenQueueVm.Remove(selectedItem);
                    UpdateDgvCitizen();

                    using (var db = new Proyecto_VacunacionContext())
                    {
                        try
                        {
                            //Seteando hora de vacunacion de elemento selecionado
                            var appoinmentDb = db.Appointments.ToList();
                            var appointmentUpdate = appoinmentDb.Find(a => (a.DuiCitizen == selectedItem.Dui) && (a.DateHourVaccination == null));
                            if(appointmentUpdate != null) appointmentUpdate.DateHourVaccination = DateTime.Now;

                            db.Update(appointmentUpdate);
                            db.SaveChanges();

                            //Actualizando dgv y lista de pacientes en espera
                            dgvWaitingQueue.DataSource = null;
                            Models.CitizenWaitingQueue.RemoveCitizenOnQueue(selectedItem.Dui);
                            dgvWaitingQueue.Refresh();
                            dgvWaitingQueue.Update();
                            CitizenOnObservation.Add(selectedItem);
                            CitizenTimerCounter.Add(MapperC.MapCitizenToCitizenTimer(selectedItem));
                           
                            UpdateDgvWaitingQueue();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Error al establecer conexion con base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }      
            }
        }
        private void UpdateDgvCitizen()
        {

            dgvWaitingCitizen.Columns.Clear();
            dgvWaitingCitizen.DataSource = null;
            dgvWaitingCitizen.DataSource = CitizenQueueVm;

            //configurando columna de botones en dgv
            DataGridViewButtonColumn buttoms = new DataGridViewButtonColumn();
            buttoms.UseColumnTextForButtonValue = true;
            buttoms.Name = "VacStatus";
            buttoms.HeaderText = "";
            buttoms.Text = "Vacunar";
            dgvWaitingCitizen.Columns.Add(buttoms);

            dgvWaitingCitizen.Columns[0].HeaderText = "DUI";
            dgvWaitingCitizen.Columns[1].HeaderText = "Nombre";

        }

        private void UpdateDgvWaitingQueue()
        {
            dgvWaitingQueue.Columns.Clear();
            dgvWaitingQueue.DataSource = null;
            dgvWaitingQueue.DataSource = CitizenOnObservation;

            //Configurando columna de botones en dgv
            DataGridViewButtonColumn buttoms = new DataGridViewButtonColumn();
            buttoms.UseColumnTextForButtonValue = true;
            buttoms.Name = "Sintomas";
            buttoms.HeaderText = "";
            buttoms.Text = "Registrar Sintoma";
            //Configurando columna de boton Dar de alta
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.UseColumnTextForButtonValue = true;
            btn.Name = "Alta";
            btn.HeaderText = "";
            btn.Text = "Dar Alta";

            dgvWaitingQueue.Columns.Add(buttoms);
            dgvWaitingQueue.Columns.Add(btn);

            dgvWaitingQueue.Columns[0].HeaderText = "DUI";
            dgvWaitingQueue.Columns[1].HeaderText = "Nombre";

        }
        //Aniade un segundo en el contador de cada ciudadano en observacion
        private void AddTimeToCitizens()
        {
            if (CitizenTimerCounter == null)
                return;
            CitizenTimerCounter.ForEach(c => c.TimeSec++);
        }

        private void dgvWaitingQueue_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            if (e.ColumnIndex == 2)
            {
                ProcessSecundaryEffect();
            }
            if(e.ColumnIndex == 3)
            {
                var selectedItem = dgvWaitingQueue.SelectedRows[0].DataBoundItem as CitizenVm;
                int minutes = CitizenTimerCounter.Find(c => c.Dui == selectedItem.Dui).TimeMinutes;
                if(MessageBox.Show($"Confimacion de alta medica. \nNombre:{selectedItem.Name}\nMinutos de espera:{minutes}.\nRecuerda que lo recomendado es esperar 30 minutos.","",MessageBoxButtons.YesNo,MessageBoxIcon.Information)== DialogResult.Yes)
                    ProcessCitizen();
            }
        }
        private void ProcessSecundaryEffect()
        {
            var citizenSelected = dgvWaitingQueue.SelectedRows[0].DataBoundItem as CitizenVm;
            SecundaryEffect secEffect = cmbSecundaryEffects.SelectedItem as SecundaryEffect;
            var minutes = CitizenTimerCounter.Find(c => c.Dui == citizenSelected.Dui).TimeMinutes;

            if (MessageBox.Show($"Registrar {secEffect.SecundaryEffect1} en {citizenSelected.Name} {minutes} minutos despues de la inyeccion.", "Nuevo Efecto Secundario", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                if (dgvWaitingQueue.CurrentRow == null) return;

                using (var db = new Proyecto_VacunacionContext())
                {
                    var appointmentsDb = db.Appointments.ToList();
                    try
                    {
                        var activeAppointment = appointmentsDb.Find(a => (a.DuiCitizen == citizenSelected.Dui) && (a.DateHourProcessed == null));
                        var appointment = new AppointmentEffect
                        {
                            Minute = minutes,
                            IdSecundaryEffect = secEffect.Id,
                            IdAppointment = activeAppointment.Id
                        };

                        //Actualizando DB
                        db.Add(appointment);
                        db.SaveChanges();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Cita no disponible", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
        }
        private void ProcessCitizen() 
        {
            var citizenSelected = dgvWaitingQueue.SelectedRows[0].DataBoundItem as CitizenVm;
            
            using(var db = new Proyecto_VacunacionContext())
            {
                var appointmentnDb = db.Appointments.ToList();
                var appointmentUpdate = appointmentnDb.Find(a => a.DuiCitizen == citizenSelected.Dui && a.DateHourProcessed == null);
                appointmentUpdate.DateHourProcessed = DateTime.Now;

                try
                {
                    db.Update(appointmentUpdate);
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al establecer conexion con base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Validacion si ciudadano aplica a segunda dosis
                int appointmetCounter = 0;

                appointmentnDb.ForEach(c =>
                {
                    if (c.DuiCitizen == citizenSelected.Dui) appointmetCounter++;
                });
                bool SecondVacAvailable = appointmetCounter == 1;

                if (SecondVacAvailable) ScheduleSecondVaccination(citizenSelected.Dui);
                else MessageBox.Show("Paciente dado de alta exitosamente", "Alta medica", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            dgvWaitingQueue.DataSource = null;
            CitizenOnObservation.Remove(citizenSelected);
            UpdateDgvWaitingQueue();
        }

        private void ScheduleSecondVaccination(int CitizenId)
        {
            var db = new Proyecto_VacunacionContext();
            var nextAppoDate = DateTime.Now.AddDays(30);
            var newAppointment = new Appointment
            {
                DuiCitizen = CitizenId,
                DateHourSchedule = nextAppoDate,
                IdCabin = 1
            };
            try
            {
                db.Add(newAppointment);
                db.SaveChanges();
                MessageBox.Show($"Programacion de segunda dosis\nDetalles de la cita:\nFecha: " + nextAppoDate.ToString("mm/dd/yy") + "\nHora:" + nextAppoDate.ToString("hh:mm tt"), "Programcion Segunda Dosis", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception)
            {
                MessageBox.Show("Error en conexion a base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                throw;
            }
        }

        private void frmVaccinationProcess_Activated(object sender, EventArgs e)
        {
            foreach (var c in Models.CitizenWaitingQueue.CitizensList)
            {
                if (!CitizenQueueVm.Exists(e => e.Dui == c.Dui))
                {
                    dgvWaitingCitizen.DataSource = null;
                    CitizenQueueVm.Add(MapperC.MapCitizenToCitizenVm(c));
                    UpdateDgvCitizen();
                }
            }
        }
    }
}
