﻿using ProyectoVacunacionCovid.VaccinationContext;
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
            if (duiFormat.IsMatch(txtDUI.Text))
            {
                var telFormat = new Regex("^[267]{1}[0-9]{7}$");
                if (telFormat.IsMatch(txtTelefono.Text))
                {
                    var correoFormat = new Regex(@"^[^\s@]+@[^\s@]+\.[^\s@]+$");
                    if (correoFormat.IsMatch(txtCorreo.Text))
                    {
                        Citizen Nombre = new Citizen()
                        {
                            Name = txtNombre.Text,
                            Dui = Int32.Parse(txtDUI.Text),
                            PhoneNumber = txtTelefono.Text,
                            Email = txtCorreo.Text,
                            DateOfBirth = dtpNacimiento.Value
                        };
                        var DB = new Proyecto_VacunacionContext();
                        var Iref = cmbInstitution.SelectedItem as Institution;
                        Nombre.IdInstitution = Iref.Id;

                        var Cref = cmbMunicipio.SelectedItem as City;
                        var Aref = new Address()
                        {
                            Location = txtLocalidad.Text,
                            IdCity = Cref.Id
                        };
                        DB.Add(Aref);

                        Nombre.IdAddress = Aref.Id;
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
                        DB.Add(Nombre);
                        DB.SaveChanges();   
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

        }

        private void cmbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            var DB = new Proyecto_VacunacionContext();
            var State = cmbDepartamento.SelectedItem as State;
            //var Conexion = DB.Addresses.Where(a=> a.IdCity.Equals(City.Id)).ToList();
            var Conexion = State.Cities.ToList();
            cmbMunicipio.DataSource = Conexion;
            cmbMunicipio.DisplayMember = "State";
            cmbMunicipio.ValueMember = "Id";
        }
    }
}