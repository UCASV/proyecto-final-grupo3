using ProyectoVacunacionCovid.VaccinationContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoVacunacionCovid
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var db = new Proyecto_VacunacionContext())
            {
                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                //Obteniendo, desde la base de datos, la cabina que usara el programa
                //En este caso la cabina con id = 1
                Cabin cabin = db.Cabins.SingleOrDefault(c =>  c.Id.Equals(1));
                //Llamando al formulario login antes que al principal
                frmLogin login = new frmLogin(cabin);
                login.ShowDialog();
                //Validando si hubo login exitoso
                if (login.SuccesLogin)
                    Application.Run(new frmMain());
                    //En lugar de frmMain, pongan el formulario que hayan hecho
            }
        }
    }
}
