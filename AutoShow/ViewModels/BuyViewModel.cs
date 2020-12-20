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
    public class BuyViewModel : INotifyPropertyChanged
    {
        int modelid; long cost; long newprice=0;
        private BuyAuto buyAuto;
        private DBOperations db;
        bool manager; string EmpFCS;
        private ReCommand close; //закрыть окно
        private ReCommand back;
        private ReCommand order;

        public ReCommand Close_Win
        {
            get
            {
                return close ??
                  (close = new ReCommand(obj =>
                  {
                      buyAuto.Close();
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
                      buyAuto.Close();
                  }));
            }
        }

        public ReCommand Order
        {
            get
            {
                return order ??
                  (order = new ReCommand(obj =>
                  {
                      OrderAuto orderAuto  = new OrderAuto(manager, EmpFCS);
                      orderAuto.ShowDialog();
                      buyAuto.Close();
                  }));
            }
        }
        private ObservableCollection<AutoModel> cars;
        public ObservableCollection<AutoModel> Cars 
        {
            get { return cars; }
            set
            {
                cars = value;
                OnPropertyChanged("Cars");
            }
        }//коллекция авто

        private ReCommand choose; //закрыть окно

        public ReCommand Choose
        {
            get
            {
                return choose ??
                  (choose = new ReCommand(obj =>
                  {
                      if (Availability == true)
                      {
                          ChooseCustEmp chooseCustEmp = new ChooseCustEmp(modelid, cost, Color, Equiptype, manager, EmpFCS, SelectedTransm.Transmission1);
                          chooseCustEmp.ShowDialog();
                          buyAuto.Close();
                        
                      }
                      else 
                      {
                          MessageBox.Show("Автомобиля нет в наличии!");
                          
                      }
                      
                  }));
            }
        }

        public ObservableCollection<BrandModel> Brands { get; set; }



        private BrandModel selectedBrand;
        public BrandModel SelectedBrand
        {
            get { return selectedBrand; }
            set
            {
                selectedBrand = value;
                //фильтрация остальных
                Cars = new ObservableCollection<AutoModel>(db.GetModels(selectedBrand.Id));
                
            }
        }

        

        private AutoModel selectedModel;
        public AutoModel SelectedModel
        {
            get { return selectedModel; }
            set
            {
                
                selectedModel = value;
                Colors = new ObservableCollection<ColorModel>(db.GetColors(selectedModel.Id));
                Plants = db.GetPlants(selectedModel.Id);
                Price = selectedModel.Price.ToString();
                Release = selectedModel.ReleaseYear.ToString();
                VechType = new ObservableCollection<VechTypeModel>(db.GetVechType(selectedModel.Id));
                Availability = selectedModel.Availability;
                cost = selectedModel.Price;
                modelid = selectedModel.Id;
                Color = SelectedColor.Id;
                Equiptype = SelectedVechType.Id;
               

            }
        }
        private ObservableCollection<ColorModel> colors;
        public ObservableCollection<ColorModel> Colors
        {
            get { return colors; }
            set
            {
                colors = value;
                OnPropertyChanged("Colors");
            }
        }
        private ColorModel selectedColor;
        public ColorModel SelectedColor 
        {
            get { return selectedColor; }
            set
            {
                selectedColor = value;
                Price = db.GetPrice(selectedModel.Id, selectedColor.Id).ToString();
                Release = db.GetYear(selectedModel.Id, selectedColor.Id).ToString();
                Availability = db.GetAvailability(selectedModel.Id, selectedColor.Id);
                OnPropertyChanged("SelectedColor"); 
            }
        }
        private ObservableCollection<VechTypeModel> vechType; 
        public ObservableCollection<VechTypeModel> VechType
        {
            get { return vechType; }
            set
            {
                vechType = value;
             
                OnPropertyChanged("VechType");
            }
        }

        private VechTypeModel selectedVechType;
        public VechTypeModel SelectedVechType
        {
            get { return selectedVechType; }
            set
            {
                selectedVechType = value;
                if (selectedVechType.EquipType != "Полный")
                {
                    newprice = selectedModel.Price - 60000;
                    cost = newprice;
                    Price = newprice.ToString();
                }
                else Price = selectedModel.Price.ToString();
                Transm = new ObservableCollection<TransmissionModel>(db.GetSelTransm(SelectedVechType.Id, SelectedModel.Id));
                OnPropertyChanged("SelectedVechType");
            }
        }

        private ObservableCollection<TransmissionModel> transm;
        public ObservableCollection<TransmissionModel> Transm
        {
            get { return transm; }
            set
            {
                transm = value;

                OnPropertyChanged("Transm");
            }
        }

        private TransmissionModel selectedTransm;
        public TransmissionModel SelectedTransm
        {
            get { return selectedTransm; }
            set
            {
                selectedTransm = value;
                if (selectedTransm.Transmission1 != "АКП" && newprice != 0)
                {
                    newprice = newprice - 30000;
                    cost = newprice;
                    Price = newprice.ToString();
                }
                else
                {
                    newprice = selectedModel.Price - 30000;
                    Price = newprice.ToString();

                }
              
                OnPropertyChanged("SelectedTransm");
            }
        }

        private PlantModel plants;
        public PlantModel Plants
        {
            get { return plants; }
            set
            {
                plants = value;
                OnPropertyChanged("Plants");
            }
        }


        private string price;
        public string Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged("Price");
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

        private bool availability;
        public bool Availability
        {
            get { return availability; }
            set
            {
                availability = value;
                OnPropertyChanged("Availability");
            }
        }


        private int color;
        public int Color
        {
            get { return color; }
            set
            {
                color = value;
                OnPropertyChanged("Color");
            }
        }

        private int quiptype;
        public int Equiptype
        {
            get { return quiptype; }
            set
            {
                quiptype = value;
                OnPropertyChanged("Equiptype");
            }
        }
        public BuyViewModel(BuyAuto buyAuto, bool manager, string EmpFCS)
        {
            this.buyAuto = buyAuto;
            db = new DBOperations();
            this.manager = manager;
            this.EmpFCS = EmpFCS;
            Brands = new ObservableCollection<BrandModel>(db.GetBrands());
            
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    
    }
}
