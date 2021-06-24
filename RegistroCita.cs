using ProyectoVacunacionCovid.VaccinationContext;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto
{
    public partial class RegistroCita : Form
    {
        public RegistroCita()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            var duiFormat = new Regex("^[0-9]{8}[0-9]{1}$");
                if (duiFormat.IsMatch(txtDUI.Text)){
                var telFormat = new Regex("^[267]{1}[0-9]{7}$");
                    if (telFormat.IsMatch(txtTelefono.Text)){
                    var correoFormat = new Regex(@"^[^\s@]+@[^\s@]+\.[^\s@]+$");
                    if (correoFormat.IsMatch(txtCorreo.Text)) {
                        Citizen Nombre = new Citizen()
                        {
                            Name = txtNombre.Text,
                            Dui = Int32.Parse(txtDUI.Text),
                            PhoneNumber = txtTelefono.Text,
                            Email = txtCorreo.Text

                        };
                        var DB = new Proyecto_VacunacionContext();
                        var Iref = cmbInstitution.SelectedItem as Institution;
                        Nombre.IdInstitution = Iref.Id;
                        Nombre.IdAddress = 1;
                        DB.Add(Nombre);
                        DB.SaveChanges();

                    }
                    else MessageBox.Show("Ingrese un correo valido.", "Proyecto Vacuanación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else MessageBox.Show("Ingrese un teléfono valido.", "Proyecto Vacuanación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else MessageBox.Show("Ingrese un DUI valido.", "Proyecto Vacuanación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void RegistroCita_Load(object sender, EventArgs e)
        {
            var DB = new Proyecto_VacunacionContext();
            var Conexion = DB.Institutions.ToList();
            cmbInstitution.DataSource = Conexion;
            cmbInstitution.DisplayMember = "Institution1";
            cmbInstitution.ValueMember = "Id";
        }
    }
}
