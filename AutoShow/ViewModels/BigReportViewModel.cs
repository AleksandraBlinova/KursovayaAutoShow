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
   public class BigReportViewModel : INotifyPropertyChanged
    {
        private DBOperations db;
        private ReCommand close; //закрыть окно
        private ReCommand menu_Manager;
        private ReCommand ok;
        bool manager; string EmpFCS; DateTime selectedDate;
        private ObservableCollection<PurchModel> purches;
        private ObservableCollection<OrderModel> orders; long totcost;

        public ReCommand Close_Win
        {
            get
            {
                return close ??
                  (close = new ReCommand(obj =>
                  {
                      bigReport.Close();
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
                      bigReport.Close();
                  }));
            }
        }

        public ReCommand OK
        {
            get
            {
                return ok ??
                  (ok = new ReCommand(obj =>
                  {
                      selectedDate = (DateTime)bigReport.SelectedDatePicker.SelectedDate;
                      Date = selectedDate.ToShortDateString();
                      purches = new ObservableCollection<PurchModel>( db.GetReportPurch(selectedDate));
                      orders= new ObservableCollection<OrderModel>(db.GetReportOrder(selectedDate));
                      PCost = purches.Sum(i => i.TotalCost).ToString();
                      OCost = orders.Sum(i => i.Cost).ToString();
                      totcost = purches.Sum(i => i.TotalCost) + orders.Sum(i => i.Cost);
                      TotalCost = totcost.ToString();

                  }));
            }
        }
        private string ocost;
        public string OCost
        {
            get { return ocost; }
            set
            {
                ocost = value;
                OnPropertyChanged("OCost");
            }
        }

        private string pcost;
        public string PCost
        {
            get { return pcost; }
            set
            {
                pcost = value;
                OnPropertyChanged("PCost");
            }
        }

        private string totalcost;
        public string TotalCost
        {
            get { return totalcost; }
            set
            {
                totalcost = value;
                OnPropertyChanged("TotalCost");
            }
        }

        private string date;
        public string Date
        {
            get { return date; }
            set
            {
                date = value;
                OnPropertyChanged("Date");
            }
        }



        private BigReport bigReport;
        public BigReportViewModel(BigReport bigReport, bool manager, string EmpFCS)
        {
            this.bigReport = bigReport;
            db = new DBOperations();
            this.manager = manager;
            this.EmpFCS = EmpFCS;
            bigReport.SelectedDatePicker.SelectedDate = DateTime.Now.Date;

        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }


    }
}

