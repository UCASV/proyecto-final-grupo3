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
        public bool SuccesLogin { get; set; }

        private Cabin Cabin { get; set; }
        public frmLogin(Cabin cabin)
        {
            InitializeComponent();
            this.SuccesLogin = false;
            this.Cabin = cabin;
        }


        private void btnInit_Click(object sender, EventArgs e)
        {
            var db = new Proyecto_VacunacionContext();
            var uss = db.Managers.ToList();
            var result = uss.Where(
                u => u.Username.Equals(txtUser.Text)
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
                    ManagerxCabin mxc = new ManagerxCabin()
                    {
                        DatetimeLogin = DateTime.Now,
                        IdCabin = this.Cabin.Id,
                        IdManager = result.First().Id
                    };
                    db.Add(mxc);
                    db.SaveChanges();

                    this.SuccesLogin = true;
                    MessageBox.Show("Bienvenido", "Gobierno de El Salvador",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
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
