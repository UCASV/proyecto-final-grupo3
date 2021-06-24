using ProyectoVacunacionCovid.Properties;
using ProyectoVacunacionCovid.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoVacunacionCovid.Entities
{
    public class WaitingCitizen
    {
        public int Dui { get; set; }
        public string Name { get; set; }
        public int CurrentTime { get; set; }
        public Bitmap Progress { get 
            {
                return new Bitmap(Resources.progressBarPic, CurrentTime * 2, 20);
            }}
        public WaitingCitizen(int Dui, string Name)
        {
            this.Dui = Dui;
            this.Name = Name;
            this.CurrentTime = 1;
           // Progress = new Bitmap(Resources.progressBarPic, 100,20);
        }
        public WaitingCitizen()
        {
        }

        private void ProgressBarBitmap()
        {
          //  Progress = new Bitmap(Resources.progressBarPic, CurrentTime * 10, 20);

        }

    }
}
