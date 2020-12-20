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
   public class OrderViewModel : INotifyPropertyChanged
    {
        private DBOperations db;
        private ReCommand close; //закрыть окно
        private ReCommand back;
        private bool manager; string EmpFCS; int selectedId; string formname;
        private ReCommand ord;
        public ReCommand Close_Win
        {
            get
            {
                return close ??
                  (close = new ReCommand(obj =>
                  {
                      order.Close();
                  }));
            }
        }
        public ReCommand Back
        {
            get
            {
                return back ??
                  (back = new ReCommand(obj =>
                  {
                      MenuManager menuManager = new MenuManager(manager, EmpFCS);
                      menuManager.ShowDialog();
                      order.Close();
                  }));
            }
        }



        private ReCommand littlerep;
        public ReCommand LittleRep
        {
            get
            {
                return littlerep ??
                  (littlerep = new ReCommand(obj =>
                  {
                      OrderModel row = (OrderModel)order.DataGOrders.SelectedItems[0];
                      selectedId = (int)row.Id;
                      formname = "Order";
                      LittleReport littleReport = new LittleReport(manager, EmpFCS, selectedId, formname);
                      littleReport.ShowDialog();
                      order.Close();
                  }));
            }
        }



        public ReCommand Order
        {
            get
            {
                return ord ??
                  (ord = new ReCommand(obj =>
                  {
                      OrderAuto orderAuto = new OrderAuto(manager, EmpFCS);
                      orderAuto.ShowDialog();
                      order.Close();
                  }));
            }
        }
        public ObservableCollection<OrderModel> AllOrders { get; set; }

        private Order order ;
        public OrderViewModel(Order order, bool manager, string EmpFCS)
        {
            db = new DBOperations();

            AllOrders = new ObservableCollection<OrderModel>(db.GetAllOrders());
            this.order = order;
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