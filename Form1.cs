using ProyectoVacunacionCovid.VaccinationContext;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoVacunacionCovid
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }


        private void btnInit_Click(object sender, EventArgs e)
        {
            var db = new Proyecto_VacunacionContext();
            var uss = db.Managers.ToList();
            var result = uss.Where(
                u => u.Username.Equals(txtUser.Text)
                        //u.Password.Equals(txtPassword.Text)
            ).ToList();

            if (result.Count == 0)
            {
                MessageBox.Show("No se encontro el usuario", "Gobierno de El Salvador",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (result.First().Password.Equals(txtPassword.Text))
                {
                    MessageBox.Show("Bienvenido", "Gobierno de El Salvador",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //frmMain window = new frmMain(result[0]);
                    //window.Show();
                    //this.Hide();
                }
                else
                {
                    MessageBox.Show("Contraseña incorrecta", "Gobierno de El Salvador",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
