using AutoShow.Models;
using AutoShow.View;
using DAL.Services;
using DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AutoShow.ViewModels
{
   public class ThanksBuyViewModel : INotifyPropertyChanged
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
                      ThanksForPurch.Close();
                  }));
            }
        }
        public long TotalCost //скидка составила
        {
            get { return totalcost; }
            set
            {
                totalcost = value;
                OnPropertyChanged("Sale");
            }
        }
        public ReCommand OK
        {
            get
            {
                return ok ??
                  (ok = new ReCommand(obj =>
                  {
                      Purchases purchases  = new Purchases(manager, EmpFCS);
                      purchases.ShowDialog();
                      ThanksForPurch.Close();
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
                      ThanksForPurch.Close();
                  }));
            }
        }

        


        private ThanksForPurch ThanksForPurch;
        public ThanksBuyViewModel(ThanksForPurch thanksBuy, bool manager, long cost, string EmpFCS)
        {
            this.ThanksForPurch = thanksBuy;
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

