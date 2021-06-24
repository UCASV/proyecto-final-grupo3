using ProyectoVacunacionCovid.Entities;
using ProyectoVacunacionCovid.Properties;
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
        public List<WaitingCitizen> queue = new List<WaitingCitizen>()
        {
                new WaitingCitizen(1,"Roberto"),
                new WaitingCitizen(2,"Oscar"),
                new WaitingCitizen(3, "Carlos"),
                new WaitingCitizen(4, "Keyla")
        };
        public frmVaccinationProcess()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void frmVaccinationProcess_Load(object sender, EventArgs e)
        {
            dgvWaitingCitizen.DataSource = queue;
            waitingTimer.Enabled = true;
            clmProgressbar.ImageLayout = DataGridViewImageCellLayout.Normal;
        }

        private void waitingTimer_Tick(object sender, EventArgs e)
        {
            foreach (var c in queue)
            {
                c.CurrentTime++;
            }
            dgvWaitingCitizen.DataSource = null;
            dgvWaitingCitizen.DataSource = queue;
        }


    }
}
