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
        public frmVaccinationProcess()
        {
            InitializeComponent();
            CitizenQueueVm = new List<CitizenVm>();
            CitizenOnObservation = new List<CitizenVm>();
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


            //dgvDatasource           
            using(var db = new Proyecto_VacunacionContext()) 
            {
                try
                {
                    CitizenQueue = db.Citizens.ToList();
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
                dgvWaitingCitizen.DataSource = null;
                dgvWaitingCitizen.DataSource = CitizenQueueVm;
            }


            //configurando columna de botones en dgv
            DataGridViewButtonColumn buttoms = new DataGridViewButtonColumn();
            buttoms.UseColumnTextForButtonValue = true;
            buttoms.HeaderText = "";
            buttoms.Text = "Vacunar";
            dgvWaitingCitizen.Columns.Add(buttoms);


        }

        private void waitingTimer_Tick(object sender, EventArgs e)
        {

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

                if (MessageBox.Show("Boton Seleccionado", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //var slect = dgvWaitingCitizen.CurrentRow.DataBoundItem as CitizenVm;
                    CitizenVm selectedItem = dgvWaitingCitizen.SelectedRows[0].DataBoundItem as CitizenVm;
                    MessageBox.Show($"{selectedItem.Name},{selectedItem.Dui} Boton Seleccionado", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    dgvWaitingCitizen.DataSource = null;
                    CitizenQueueVm.Remove(selectedItem);
                    dgvWaitingCitizen.DataSource = CitizenQueueVm;
                    CitizenOnObservation.Add(selectedItem);

                    dgvWaitingCitizen.DataSource = null;
                    dgvWaitingCitizen.DataSource = CitizenOnObservation;
                    
                    
                }
                    
                
            }
        }
    }
}
