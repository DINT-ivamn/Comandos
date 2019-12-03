using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Comandos
{
    public class HoraActual : INotifyPropertyChanged
    {
        private string hora;
        public string Hora
        {
            get
            {
                return hora;
            }
            set
            {
                hora = value;
                NotifyPropertyChanged("Hora");
            }
        }

        public HoraActual()
        {
            Hora = DateTime.Now.ToLongTimeString();
            Timer timer = new Timer(1000);
            timer.Elapsed += CambiarHora;
            timer.Start();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void CambiarHora(object sender, ElapsedEventArgs e)
        {
            Hora = DateTime.Now.ToLongTimeString();
        }
    }
}
