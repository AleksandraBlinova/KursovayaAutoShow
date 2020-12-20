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
   public class OrderAutoViewModel : INotifyPropertyChanged
    {
        int modelid; 
        private OrderAuto order ;
        private DBOperations db;
        bool manager; string EmpFCS;
        private ReCommand close; //закрыть окно
        private ReCommand back;
        private AutoModel car;
        private VechTypeModel vech;
        long cost;

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

        public ReCommand Choose
        {
            get
            {
                return choose ??
                  (choose = new ReCommand(obj =>
                  {
                      //if (Availability == false)
                      //{


                      //}
                      //else
                      //{
                      //    MessageBox.Show("Автомобиль есть в наличии!");

                      //}
                      car = new AutoModel();
                      car.Availability = false;
                      car.Brand = SelectedBrand.Brand1;
                      car.Color = SelectedColor.Color1;
                      car.HP = SelectedVechType.HP;
                      car.Model = SelectedModel.Model;
                      car.Plant = SelectedModel.Plant;
                      car.Price = cost;
                      car.ReleaseYear = SelectedModel.ReleaseYear;
                      car.Speed = SelectedVechType.Speed;
                      car.Transm = SelectedTransm.Transmission1;
                      car.Id = db.CreateAuto(SelectedModel.Id, SelectedColor.Id, Plants.Id, (int)cost, car.ReleaseYear);
                      ChooseOrder chooseOrder  = new ChooseOrder( manager, EmpFCS, car.Id, SelectedVechType.Id);
                      chooseOrder.ShowDialog();
                      
                      
                      order.Close();

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
                Colors = new ObservableCollection<ColorModel>(db.GetAllColors());
                Plants = db.GetPlants(selectedModel.Id);
                Price = selectedModel.Price.ToString();
                Release = "2020";
                VechType = new ObservableCollection<VechTypeModel>(db.GetVechType(selectedModel.Id));
                modelid = selectedModel.Id;
                Color = SelectedColor.Id;
                //Availability = selectedModel.Availability;

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

                //Availability = db.GetAvailability(selectedModel.Id, selectedColor.Id);
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
                Equiptype = SelectedVechType.Id;
                Speed = SelectedVechType.Speed;
                HP = SelectedVechType.HP;
                if (selectedVechType.EquipType != "Полный")
                {
                    cost = selectedModel.Price - 50000;
                    Price = cost.ToString();
                }
                else Price = selectedModel.Price.ToString();
                OnPropertyChanged("SelectedVechType");
            }
        }


        private ObservableCollection<TransmissionModel> transmission;
        public ObservableCollection<TransmissionModel> Transmission
        {
            get { return transmission; }
            set
            {
                transmission = value;
                OnPropertyChanged("Transmission");
            }
        }

        private TransmissionModel selectedtransm;
        public TransmissionModel SelectedTransm
        {
            get { return selectedtransm; }
            set
            {
                selectedtransm = value;
                if (selectedtransm.Transmission1 != "АКП" && cost != 0)
                {
                    cost = cost - 30000;
                    Price = cost.ToString();
                }
                else
                {
                    cost = selectedModel.Price - 30000;
                    Price = cost.ToString();

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


        private int hp;
        public int HP
        {
            get { return hp; }
            set
            {
                hp = value;
                OnPropertyChanged("HP");
            }
        }

        private int speed;
        public int Speed
        {
            get { return speed; }
            set
            {
                speed = value;
                OnPropertyChanged("Speed");
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


      

        public OrderAutoViewModel(OrderAuto order, bool manager, string EmpFCS)
        {
            this.order = order;
            db = new DBOperations();
            this.manager = manager;
            this.EmpFCS = EmpFCS;
            Brands = new ObservableCollection<BrandModel>(db.GetBrands());
            Transmission = new ObservableCollection<TransmissionModel>(db.GetAllTransm());
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }


    }
}
