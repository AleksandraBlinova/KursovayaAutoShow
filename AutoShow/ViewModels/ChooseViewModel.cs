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
    public class ChooseViewModel : INotifyPropertyChanged
    {
        int modelid; long cost; int color; int equip; bool manager; string EmpFCS;
        private ChooseCustEmp chooseCustEmp;
        private DBOperations db;
        private ReCommand close; //закрыть окно

        public ReCommand Close_Win
        {
            get
            {
                return close ??
                  (close = new ReCommand(obj =>
                  {
                      chooseCustEmp.Close();
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

                      BuyAuto buyAuto  = new BuyAuto(manager, EmpFCS);
                      buyAuto.ShowDialog();
                      chooseCustEmp.Close();
                  }));
            }
        }


        private ReCommand typepay;
        public ReCommand TypePay
        {
            get
            {
                return typepay ??
                  (typepay = new ReCommand(obj =>
                  {

                      TypePay typePay  = new TypePay(modelid, cost, color, equip, selectedClient.Id, Employee, manager);
                      typePay.ShowDialog();
                      chooseCustEmp.Close();
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


        public ChooseViewModel(ChooseCustEmp chooseCustEmp, int modelid, long cost, int color, int equip, bool manager, string EmpFCS)
        {
            this.chooseCustEmp = chooseCustEmp;
            db = new DBOperations();
            clients = new ObservableCollection<ClientModel>(db.GetAllClients());
            Employee = EmpFCS;
            this.modelid = modelid;
            this.cost = cost;
            this.color = color;
            this.equip = equip;
            this.manager = manager;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }


    }
}

