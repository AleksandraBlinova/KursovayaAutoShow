using DAL;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModels
{
    public class AutoModel 
    {
        public int Id { get; set; }
        public bool Availability { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public long Price { get; set; }
        public string Color { get; set; }
        public string Transm { get; set; }
        public int HP { get; set; }
        public int Speed { get; set; }
        public int ReleaseYear { get; set; }
        public string Plant { get; set; }


        public AutoModel() { }
        public AutoModel(Automobile a)
        {
          Id = a.Id;
          Availability = a.Availability;
          Brand = a.VehicleEquip.Model.Brand.Brand1;
          Model = a.VehicleEquip.Model.Model1;
          Color = a.Color.Color1;
          Price = a.Price;
          Transm = a.VehicleEquip.Transmission.Transmission1;
          HP = a.VehicleEquip.HP;
          Speed = a.VehicleEquip.Speed;
          ReleaseYear = a.ReleaseYear;
          Plant = a.Plant.PlantName;


        }
    }
}
