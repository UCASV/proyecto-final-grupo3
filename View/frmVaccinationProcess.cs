using Microsoft.EntityFrameworkCore;
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
        public List<Citizen> CitizenQueue { get; set; }
        public List<CitizenVm> CitizenOnObservation { get; set; }
        public List<SecundaryEffect> SecundaryEffectsList { get; set; }
        public frmVaccinationProcess()
        {
            InitializeComponent();
            CitizenQueueVm = new List<CitizenVm>();
            CitizenOnObservation = new List<CitizenVm>();
            SecundaryEffectsList = new List<SecundaryEffect>();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void frmVaccinationProcess_Load(object sender, EventArgs e)
        {
            //hiding tabsHeaders on tabControl
            tabMain.ItemSize = new Size(0, 1);
            tabMain.SizeMode = TabSizeMode.Fixed;
            tabMain.TabStop = false;

            waitingTimer.Enabled = true;
            //dgvDatasource           
            using(var db = new Proyecto_VacunacionContext()) 
            {
                try
                {
                    CitizenQueue = db.Citizens.ToList();
                    SecundaryEffectsList = db.SecundaryEffects.ToList();
                }
                catch (Exception)
                {
                    MessageBox.Show("Ërror en base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }
                foreach (var c in CitizenQueue)
                {
                    CitizenQueueVm.Add(MapperC.MapCitizenToCitizenVm(c));
                }   
            }
            //Following methon causes exception on indexrow
            //UpdateDgvWaitingQueue();
            UpdateDgvCitizen();
        }

        private void waitingTimer_Tick(object sender, EventArgs e)
        {
            lblTimer.Text = DateTime.Now.ToString("hh:mm tt");
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
                            var updateAp = appoinmentDb.Find(a => (a.DuiCitizen == selectedItem.Dui) && (a.DateHourVaccination == null));
                            if(updateAp != null) updateAp.DateHourVaccination = DateTime.Now;

                            db.Update(updateAp);
                            db.SaveChanges();

                            //Actualizando dgv y lista de pacientes en espera
                            dgvWaitingQueue.DataSource = null;
                            dgvWaitingQueue.Refresh();
                            dgvWaitingQueue.Update();
                            CitizenOnObservation.Add(selectedItem);
                           
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

            comboBox1.DataSource = SecundaryEffectsList;
            comboBox1.DisplayMember = "SecundaryEffect1";
            comboBox1.ValueMember = "Id";

            //Configurando columna de botones en dgv
            DataGridViewButtonColumn buttoms = new DataGridViewButtonColumn();
            buttoms.UseColumnTextForButtonValue = true;
            buttoms.Name = "Sintomas";
            buttoms.HeaderText = "";
            buttoms.Text = "Registrar Sintoma";
            dgvWaitingQueue.Columns.Add(buttoms);

            dgvWaitingQueue.Columns[0].HeaderText = "DUI";
            dgvWaitingQueue.Columns[1].HeaderText = "Nombre";

        }

        private void LoadCmbColumn()
        {
            //Configurando columna ComboBox
            DataGridViewComboBoxColumn cmbColumn = new DataGridViewComboBoxColumn();

            cmbColumn.DataSource = SecundaryEffectsList;
            cmbColumn.DataPropertyName = "SecundaryEffectsList";
            cmbColumn.ValueMember = "Id";
            cmbColumn.DisplayMember = "SecundaryEffect1";
            cmbColumn.Name = "cmbEffects";
            dgvWaitingQueue.Columns.Add(cmbColumn);


            /*
            DataGridViewComboBoxColumn cmbColumn = new DataGridViewComboBoxColumn();
            cmbColumn.HeaderText = "Tipo de efecto secundario";
            SecundaryEffectsList.ForEach(s => cmbColumn.Items.Add(s));
            cmbColumn.DisplayMember = "SecundaryEffect1";
            cmbColumn.ValueMember = "Id";
            dgvWaitingQueue.Columns.Add(cmbColumn);
            */
        }
    }
}
