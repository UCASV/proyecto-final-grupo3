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

        public Cabin cabina;
        public Citizen ciudadano;
        public RegistroCita(Cabin cabina)
        {
            InitializeComponent();
            this.cabina = cabina;


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private bool validaciones(int Dui, string tel)
        {
            var DB = new Proyecto_VacunacionContext();
            var SC = DB.Citizens.ToList();
            bool validate = true;
            foreach (Citizen l in SC)

            {
                if (l.Dui == Dui || l.PhoneNumber == tel)
                {
                    validate = false;
                    MessageBox.Show("El DUI o el telefono ya existe favor revisar campos", "Proyecto Vacunación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return validate;
                }

            }
            return validate;
        }
        private void btnContinuar_Click(object sender, EventArgs e)
        {
            var duiFormat = new Regex("^[0-9]{8}[0-9]{1}$");
            if (duiFormat.IsMatch(txtDUI.Text))
            {
                var telFormat = new Regex("^[267]{1}[0-9]{7}$");
                if (telFormat.IsMatch(txtTelefono.Text))
                {
                    var correoFormat = new Regex(@"^[^\s@]+@[^\s@]+\.[^\s@]+$");
                    if (correoFormat.IsMatch(txtCorreo.Text))
                    {
                        var DB = new Proyecto_VacunacionContext();
                        if(validaciones(Int32.Parse(txtDUI.Text), txtTelefono.Text))
                        {
                            
                           
                             
                                var Cref = cmbMunicipio.SelectedItem as City;
                                var Aref = new Address()
                                {
                                    Location = txtLocalidad.Text,
                                    IdCity = Cref.Id
                                };

                                DB.Add(Aref);
                                DB.SaveChanges();
                                var ADB = DB.Addresses.ToList().Last();
                                Citizen Nombre = new Citizen()
                                {
                                    Name = txtNombre.Text,
                                    Dui = Int32.Parse(txtDUI.Text),
                                    PhoneNumber = txtTelefono.Text,
                                    Email = txtCorreo.Text,
                                    DateOfBirth = dtpNacimiento.Value,
                                    IdAddress = ADB.Id


                                };

                                var Iref = cmbInstitution.SelectedItem as Institution;
                                Nombre.IdInstitution = Iref.Id;

                                var Eref = clbEnfermedades.CheckedItems;
                                UserDisease usd;

                                foreach (ChronicleDisease cd in Eref)
                                {
                                    usd = new UserDisease()
                                    {
                                        DuiCitizen = Nombre.Dui,
                                        IdChronicleDisease = cd.Id
                                    };

                                    DB.Add(usd);

                                };
                                this.ciudadano = Nombre;
                                DB.Add(Nombre);
                                DB.SaveChanges();
                                tabControl.SelectedIndex = 1;
                            
                        }
                        
                    }
                    else
                        MessageBox.Show("Ingrese un correo valido.", "Proyecto Vacuanación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                    MessageBox.Show("Ingrese un teléfono valido.", "Proyecto Vacuanación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                MessageBox.Show("Ingrese un DUI valido.", "Proyecto Vacuanación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            
        }

        private void RegistroCita_Load(object sender, EventArgs e)
        {
            var DB = new Proyecto_VacunacionContext();
            var Conexion = DB.Institutions.ToList();
            cmbInstitution.DataSource = Conexion;
            cmbInstitution.DisplayMember = "Institution1";
            cmbInstitution.ValueMember = "Id";

            var Load = DB.States.ToList();
            cmbDepartamento.DataSource = Load;
            cmbDepartamento.DisplayMember = "State1";
            cmbDepartamento.ValueMember = "Id";

            var Disease = DB.ChronicleDiseases.ToList();
            clbEnfermedades.DataSource = Disease;
            clbEnfermedades.DisplayMember = "ChronicleDisease1";
            clbEnfermedades.ValueMember = "Id";

            tabControl.Appearance = TabAppearance.FlatButtons;
            tabControl.ItemSize = new Size(0, 1);
            tabControl.SizeMode = TabSizeMode.Fixed;
            tabControl.TabStop = false;

        }

        private void cmbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            var DB = new Proyecto_VacunacionContext();
            var State = cmbDepartamento.SelectedItem as State;
            var Conexion = DB.Cities.Where(a=> a.IdState.Equals(State.Id)).ToList();
            cmbMunicipio.DataSource = Conexion;
            cmbMunicipio.DisplayMember = "City1";
            cmbMunicipio.ValueMember = "Id";
        }

        private void registrar_Cita(Citizen nombre) 
        {
            var DB = new Proyecto_VacunacionContext();
            var lista = DB.Appointments.Where(a => a.IdCabin.Equals(this.cabina.Id));
            var Cita = new Appointment()
            {
                DuiCitizen = nombre.Dui 
            };
              foreach (Appointment l in lista)
            {
               
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            
            DateTime one = dtpCita.Value;
            if (one <= DateTime.Now)
            {
                MessageBox.Show("No es posible agendar su cita en esa fecha", "Proyecto Vacunación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {

                if (one.Hour < 8 || one.Hour >= 17)
                {
                    MessageBox.Show("La cita debe ser entre las 8 am y las 16:59 pm", "Proyecto Vacunación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    var DB = new Proyecto_VacunacionContext();
                    var lista = DB.Appointments.Where(a => a.IdCabin.Equals(this.cabina.Id) && a.DateHourSchedule >= DateTime.Now)
                        .OrderBy(a => a.DateHourSchedule);
                    bool validate = true;
                    foreach (Appointment l in lista)
                    {
                        if (DateTime.Compare(one, l.DateHourSchedule.GetValueOrDefault()) == 0)
                        {
                            validate = false;
                            MessageBox.Show("No es posible agendar su cita en esa fecha", "Proyecto Vacunación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            break;
                        }

                    }
                    if (validate)
                    {
                        var nombre = this.ciudadano.Dui;
                        Appointment ap = new Appointment()
                        {
                            DateHourSchedule = one,
                            IdCabin = this.cabina.Id,
                            DuiCitizen = nombre
                        };

                        DB.Add(ap);
                        DB.SaveChanges();

                    }
                }            
            
            }
            
        }

         private void dtpCita_ValueChanged(object sender, EventArgs e)
        {
             DateTime mediaHora = dtpCita.Value;
            if (mediaHora.Minute > 0 && mediaHora.Minute < 30)
            {
                mediaHora = mediaHora.Date + new TimeSpan(mediaHora.Hour, 0, 0);
             }
             else
            {
                if (mediaHora.Minute > 30 && mediaHora.Minute < 60)
                {
                    mediaHora = mediaHora.Date + new TimeSpan(mediaHora.Hour + 1, 0, 0);
                }
                
            }
            dtpCita.Value = mediaHora;
            
         
        }
    }
}
