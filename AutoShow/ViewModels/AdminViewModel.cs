using DAL.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AutoShow.ViewModels
{
    public class AdminViewModel : INotifyPropertyChanged
    {
        private ReCommand close; 
        public ReCommand Close_Win
        {
            get
            {
                return close ??
                  (close = new ReCommand(obj =>
                  {
                      menuAdm.Close(); 
                  }));
            }
        }


        private ReCommand cars; 
        public ReCommand Cars
        {
            get
            {
                return cars ??
                  (cars = new ReCommand(obj =>
                  {

                      Automobiles automobiles = new Automobiles();
                      automobiles.ShowDialog(); 
                      menuAdm.Close();
                  }));
            }
        }


        private ReCommand clients;
        public ReCommand Cli
        {
            get
            {
                return clients ??
                  (clients = new ReCommand(obj =>
                  {

                       Clients clients= new Clients();
                      clients.ShowDialog();
                      menuAdm.Close();
                  }));
            }
        }

        private MenuAdministr menuAdm;
        public AdminViewModel(MenuAdministr menuAdm)
        {
            this.menuAdm = menuAdm;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    
    }
}
