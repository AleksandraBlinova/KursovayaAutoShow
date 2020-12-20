using AutoShow.Models;
using AutoShow.View;
using DAL.Services;
using DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AutoShow.ViewModels
{
   public class LittleReportViewModel : INotifyPropertyChanged
    {
        private DBOperations db;
        private ReCommand close; //закрыть окно
        private ReCommand menu_Manager;
        bool manager; string EmpFCS; int selectedId; string formname;
        PurchModel selectedPurch;
        OrderModel selectedOrder;


        public ReCommand Close_Win
        {
            get
            {
                return close ??
                  (close = new ReCommand(obj =>
                  {
                      littleReport.Close();
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
                      littleReport.Close();
                  }));
            }
        }

        private string cost;
        public string Cost
        {
            get { return cost; }
            set
            {
                cost = value;
                OnPropertyChanged("Cost");
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

        private string emp;
        public string Emp
        {
            get { return emp; }
            set
            {
                emp = value;
                OnPropertyChanged("Emp");
            }
        }

        private string client;
        public string Client
        {
            get { return client; }
            set
            {
                client = value;
                OnPropertyChanged("Client");
            }
        }


        private string transm;
        public string Transm
        {
            get { return transm; }
            set
            {
                transm = value;
                OnPropertyChanged("Client");
            }
        }

        private string plant;
        public string Plant
        {
            get { return plant; }
            set
            {
                plant = value;
                OnPropertyChanged("Plant");
            }
        }
        private string release;
        public string Release
        {
            get { return release; }
            set
            {
                release = value;
                OnPropertyChanged("Release");
            }
        }

        private string brand;
        public string Brand
        {
            get { return brand; }
            set
            {
                brand = value;
                OnPropertyChanged("Brand");
            }
        }


        private string color;
        public string Color
        {
            get { return color; }
            set
            {
                color = value;
                OnPropertyChanged("Color");
            }
        }


        private string model;
        public string Model
        {
            get { return model; }
            set
            {
                model = value;
                OnPropertyChanged("Model");
            }
        }

        private string quiptype;
        public string Equiptype
        {
            get { return quiptype; }
            set
            {
                quiptype = value;
                OnPropertyChanged("Equiptype");
            }
        }



        private LittleReport littleReport ;
        public LittleReportViewModel(LittleReport littleReport, bool manager, string EmpFCS, int selectedId, string formname)
        {
            this.littleReport = littleReport;
            db = new DBOperations();
            this.manager = manager;
            this.EmpFCS = EmpFCS;
            this.selectedId = selectedId;           
            this.formname = formname;

            if (formname == "Purchase")
            {
                selectedPurch = db.GetPurch(selectedId);
                this.Brand = selectedPurch.Brand;
                this.Model = selectedPurch.Model;
                this.Color = selectedPurch.Color;
                this.Equiptype = selectedPurch.EquipType;
                this.Transm = selectedPurch.Transm;
                this.Plant = selectedPurch.Plant;
                this.Release = selectedPurch.ReleaseYear.ToString();
                this.Client = selectedPurch.CliFCS;
                this.Emp = selectedPurch.EmpFCS;
                this.Date = selectedPurch.PurchDate;
                this.Cost = selectedPurch.TotalCost.ToString();
            }
           
            else
            {
                selectedOrder = db.GetOrder(selectedId);
                this.Brand = selectedOrder.Brand;
                this.Model = selectedOrder.Model;
                this.Color = selectedOrder.Color;
                this.Equiptype = selectedOrder.EquipType;
                this.Transm = selectedOrder.Transm;
                this.Plant = selectedOrder.Plant;
                this.Release = selectedOrder.ReleaseYear.ToString();
                this.Client = selectedOrder.CliFCS;
                this.Emp = selectedOrder.EmpFCS;
                this.Date = selectedOrder.OrderDate;
                this.Cost = selectedOrder.Cost.ToString();
            }

        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }


    }
}
