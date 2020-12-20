using AutoShow.Models;
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
    public class ThankOrdViewModel : INotifyPropertyChanged
    {
        private DBOperations db;
        private ReCommand close; //закрыть окно
        private ReCommand ok;
        private ReCommand menu_Manager;
        long totalcost;
        bool manager; string EmpFCS;


        public ReCommand Close_Win
        {
            get
            {
                return close ??
                  (close = new ReCommand(obj =>
                  {
                      thanksForOrder.Close();
                  }));
            }
        }
        public long TotalCost 
        {
            get { return totalcost; }
            set
            {
                totalcost = value;
                OnPropertyChanged("TotalCost");
            }
        }
        public ReCommand OK
        {
            get
            {
                return ok ??
                  (ok = new ReCommand(obj =>
                  {
                     Order order  = new Order(manager, EmpFCS);
                      order.ShowDialog();
                      thanksForOrder.Close();
                  }));
            }
        }

        public ReCommand Menu_Manager
        {
            get
            {
                return menu_Manager ??
                  (menu_Manager = new ReCommand(obj =>
                  {
                      MenuManager manag = new MenuManager(manager, EmpFCS);
                      manag.ShowDialog();
                      thanksForOrder.Close();
                  }));
            }
        }




        private ThanksForOrder thanksForOrder;
        public ThankOrdViewModel(ThanksForOrder thanksForOrder , bool manager, long cost, string EmpFCS)
        {
            this.thanksForOrder = thanksForOrder;
            db = new DBOperations();
            this.manager = manager;
            TotalCost = cost;
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

