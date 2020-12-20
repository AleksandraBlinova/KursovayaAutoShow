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
   public  class ChooseOrderViewModel : INotifyPropertyChanged
    {
        int carid;  bool manager; string EmpFCS; int equip;
        private ChooseOrder chooseOrder;
        private DBOperations db;
        private ReCommand close; //закрыть окно
        private OrderModel order;
        public VechTypeModel VechType;
        EmployeeModel Emp;
        public AutoModel Cars { get; set; } // авто по запросу
      
        public ReCommand Close_Win
        {
            get
            {
                return close ??
                  (close = new ReCommand(obj =>
                  {
                      chooseOrder.Close();
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

                      OrderAuto orderAuto  = new OrderAuto(manager, EmpFCS);
                      orderAuto.ShowDialog();
                      chooseOrder.Close();
                  }));
            }
        }


        private ReCommand makeorder;
        public ReCommand MakeOrder
        {
            get
            {
                return makeorder ??
                  (makeorder = new ReCommand(obj =>
                  {
                      order = new OrderModel();
                      order.CliFCS = SelectedClient.FCS;
                      order.EmpFCS = EmpFCS;
                      order.OrderDate = DateTime.Now.ToString();
                      order.Brand = Cars.Brand;
                      order.Model = Cars.Model;
                      order.Plant = Cars.Plant;
                      order.Color = Cars.Color;
                      order.ReleaseYear = Cars.ReleaseYear;
                      order.EquipType = VechType.EquipType;
                      order.Transm = Cars.Transm;
                      order.Cost = (int)Cars.Price;
                      order.Id = db.CreateOrder(order, carid, SelectedClient.Id, Emp.Id, VechType.Id, SelectedType.Id);

                      ThanksForOrder thanksForOrder  = new ThanksForOrder(manager, Cars.Price, EmpFCS);
                      thanksForOrder.ShowDialog();
                      chooseOrder.Close();
                  }));
            }
        }


        public ObservableCollection<ClientModel> clients { get; set; }

        private ClientModel selectedClient;
        public ClientModel SelectedClient
        {
            get { return selectedClient; }
            set
            {
                selectedClient = value;
                OnPropertyChanged("SelectedClient");

            }
        }

        private string employee;
        public string Employee
        {
            get { return employee; }
            set
            {
                employee = value;
                OnPropertyChanged("Employee");

            }
        }


        public ObservableCollection<PayTypeModel> paytype { get; set; }

        private PayTypeModel selectedType;
        public PayTypeModel SelectedType
        {
            get { return selectedType; }
            set
            {
                selectedType = value;
                OnPropertyChanged("SelectedType");

            }
        }


        public ChooseOrderViewModel(ChooseOrder chooseOrder ,  bool manager, string EmpFCS, int carid, int equip)
        {
            this.chooseOrder = chooseOrder;
            db = new DBOperations();
            paytype = new ObservableCollection<PayTypeModel>(db.GetTypes());
            clients = new ObservableCollection<ClientModel>(db.GetAllClients());
            Employee = EmpFCS;
            this.carid = carid;
            this.manager = manager;
            this.equip = equip;
            VechType = db.GetEqType(equip);
            Cars =db.GetCars(carid);
            Emp = db.GetEmp(Employee);
           
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }


    }
}
