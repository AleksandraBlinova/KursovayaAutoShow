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
        bool admin;
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
        private ReCommand back;
        public ReCommand Back
        {
            get
            {
                return back ??
                  (back = new ReCommand(obj =>
                  {

                      Authorization authorization = new Authorization();
                      authorization.ShowDialog();
                      menuAdm.Close();
                  }));
            }
        }



        private ReCommand staff;
        public ReCommand Staff
        {
            get
            {
                return staff ??
                  (staff = new ReCommand(obj =>
                  {

                      Employees employees  = new Employees(admin);
                      employees.ShowDialog();
                      menuAdm.Close();
                  }));
            }
        }


        

        private MenuAdministr menuAdm;
        public AdminViewModel(MenuAdministr menuAdm, bool admin)
        {
            this.menuAdm = menuAdm;
            this.admin = admin;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    
    }
}
