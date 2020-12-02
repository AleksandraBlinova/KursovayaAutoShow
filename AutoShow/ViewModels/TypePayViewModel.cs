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
using System.Windows;

namespace AutoShow.ViewModels
{
  public  class TypePayViewModel : INotifyPropertyChanged
    {
        int modelid; long cost; int color; int equip; int client; int emp; bool manager;
        private TypePay typePay;
        private DBOperations db;
        private ReCommand close; //закрыть окно
        public ClientModel Client;
        public EmployeeModel Employee;
        public VechTypeModel VechType;
        private PurchModel purch;
        public ObservableCollection<CarModel> Cars { get; set; } //коллекция авто по запросу
        private AutoModel Car;
   //   ObservableCollection<Purchases> purchases { get; set; } //коллекция продаж автомобилей

        public ReCommand Close_Win
        {
            get
            {
                return close ??
                  (close = new ReCommand(obj =>
                  {
                      typePay.Close();
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

                      ChooseCustEmp chooseCustEmp  = new ChooseCustEmp(modelid, cost, color, equip, manager);
                      chooseCustEmp.ShowDialog();
                      typePay.Close();
                  }));
            }
        }

        private ReCommand buy;
        public ReCommand Buy
        {
            get
            {
                return buy ??
                  (buy = new ReCommand(obj =>
                  {
                      purch = new PurchModel();
                      purch.CliFCS = Client.FCS;
                      purch.EmpFCS = Employee.FCS;
                      purch.PurchDate = DateTime.Now.ToString();
                      purch.Brand = Car.Brand;
                      purch.Model = Car.Model;
                      purch.Plant = Car.Plant;
                      purch.Color = Car.Color;
                      purch.ReleaseYear = Car.ReleaseYear;
                      purch.TotalCost = cost;
                      purch.PayType = SelectedType.PayType;
                      purch.EquipType = VechType.EquipType;
                      purch.Transm = Car.Transm;
                      purch.Id = db.CreatePurch(purch, Car.Id, client, emp, SelectedType.Id, VechType.Id);
                      ThanksForPurch thanksForPurch  = new ThanksForPurch(manager, cost);
                      thanksForPurch.ShowDialog();
                      typePay.Close();

                  }));
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




        public TypePayViewModel(TypePay typePay, int modelid, long cost, int color, int equip, int client, int emp, bool manager)
        {
            
            db = new DBOperations();
            paytype = new ObservableCollection<PayTypeModel>(db.GetTypes());
            this.modelid = modelid;
            this.cost = cost;
            this.client = client;
            this.emp = emp;
            this.color = color;
            this.equip = equip;
            this.typePay = typePay;
            Client = db.GetClient(client);
            Employee = db.GetEmp(emp);
            VechType = db.GetEqType(equip);
            Cars = new ObservableCollection<CarModel>( db.GetCars(modelid,color));
            Car= db.GetCar(equip);
            
           
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }


    }
}



