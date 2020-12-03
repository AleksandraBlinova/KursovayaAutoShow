using AutoShow.View;
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
    class ManagViewModel : INotifyPropertyChanged
    {
        bool manager; string EmpFCS;
        private ReCommand close;
        public ReCommand Close_Win
        {
            get
            {
                return close ??
                  (close = new ReCommand(obj =>
                  {
                      menuMan.Close();
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

                      Authorization authorization  = new Authorization();
                      authorization.ShowDialog();
                      menuMan.Close();
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

                      Automobiles automobiles = new Automobiles(manager, EmpFCS);
                      automobiles.ShowDialog();
                      menuMan.Close();
                  }));
            }
        }

        private ReCommand purchase;
        public ReCommand Purchase
        {
            get
            {
                return purchase ??
                  (purchase = new ReCommand(obj =>
                  {

                      Purchases purchases   = new Purchases(manager, EmpFCS);
                      purchases.ShowDialog();
                      menuMan.Close();
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

                      Clients clients = new Clients(manager, EmpFCS);
                      clients.ShowDialog();
                      menuMan.Close();
                  }));
            }
        }

        private MenuManager menuMan;
        public ManagViewModel(MenuManager menuMan, bool manager, string EmpFCS)
        {
            this.menuMan = menuMan;
            this.manager = manager;
            this.EmpFCS = EmpFCS;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }


    }
}

    