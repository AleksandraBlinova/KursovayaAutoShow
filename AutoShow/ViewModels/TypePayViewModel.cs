﻿using AutoShow.Models;
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
        int modelid; long cost; int color; int equip; int client; string EmpFCS; bool manager; string transm;
        private TypePay typePay;
        private DBOperations db;
        private ReCommand close; //закрыть окно
        public ClientModel Client;
        EmployeeModel Employee;
        public VechTypeModel VechType;
        private PurchModel purch;
        //public ObservableCollection<CarModel> Cars { get; set; } //коллекция авто по запросу
        private AutoModel Car;
  

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

                      ChooseCustEmp chooseCustEmp  = new ChooseCustEmp(modelid, cost, color, equip, manager, EmpFCS, transm);
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
                      purch.EmpFCS = EmpFCS;
                      purch.PurchDate = DateTime.Now.ToString();
                      purch.Brand = Car.Brand;
                      purch.Model = Car.Model;
                      purch.Plant = Car.Plant;
                      purch.Color = Car.Color;
                      purch.ReleaseYear = Car.ReleaseYear;
                      purch.PayType = SelectedType.PayType;
                      purch.EquipType = VechType.EquipType;
                      purch.Transm = transm;
                      purch.ExtraServ = SelectedExtraServ.ServName;
                      purch.TotalCost = (long)(cost + SelectedExtraServ.ServCost);
                      purch.Id = db.CreatePurch(purch, Car.Id, client, Employee.Id, SelectedType.Id, VechType.Id,SelectedExtraServ.Id);
                      db.UpdateAuto(Car);


                      ThanksForPurch thanksForPurch  = new ThanksForPurch(manager, cost, EmpFCS);
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


        public ObservableCollection<ExtraServModel> extraserv { get; set; }

        private ExtraServModel selectedextraServ;
        public ExtraServModel SelectedExtraServ
        {
            get { return selectedextraServ; }
            set
            {
                selectedextraServ = value;
                OnPropertyChanged("SelectedExtraServ");

            }
        }

        public TypePayViewModel(TypePay typePay, int modelid, long cost, int color, int equip, int client, string EmpFCS, bool manager, string transm)
        {
            
            db = new DBOperations();
            paytype = new ObservableCollection<PayTypeModel>(db.GetTypes());
            extraserv= new ObservableCollection<ExtraServModel>(db.GetExtraServ());
            this.modelid = modelid;
            this.cost = cost;
            this.client = client;
            this.transm = transm;
            this.color = color;
            this.equip = equip;
            this.typePay = typePay;
            Client = db.GetClient(client);
            Employee = db.GetEmp(EmpFCS);
            VechType = db.GetEqType(equip);
            //Cars = new ObservableCollection<CarModel>( db.GetCars(modelid,color));
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



