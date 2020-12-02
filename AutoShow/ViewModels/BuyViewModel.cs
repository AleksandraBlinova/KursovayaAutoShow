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
        int modelid; long cost; 
        private BuyAuto buyAuto;
        private DBOperations db;
        bool manager;
        private ReCommand close; //закрыть окно
        
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
                          ChooseCustEmp chooseCustEmp = new ChooseCustEmp(modelid, cost, Color, Equiptype, manager);
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
                Availability = selectedModel.Availability;
                VechType = new ObservableCollection<VechTypeModel>(db.GetVechType(selectedModel.Id));
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
                OnPropertyChanged("SelectedVechType");
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
        public BuyViewModel(BuyAuto buyAuto, bool manager)
        {
            this.buyAuto = buyAuto;
            db = new DBOperations();
            this.manager = manager;
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
