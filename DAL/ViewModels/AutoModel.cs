using DAL;
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

        public long Price { get; set; }

        public bool Availability { get; set; }

        public int ReleaseYear { get; set; }

        public string Plant { get; set; }

        public string Brand { get; set; }
        public string Country { get; set; }

        public string Color { get; set; }

        public string Model { get; set; }

        public string Transm { get; set; }

        public AutoModel() { }
        public AutoModel(Automobile a)
        {
          Id = a.Id;
            Price = a.Price;
            Availability = a.Availability;
            ReleaseYear = a.ReleaseYear;
            Plant = a.Plant;
            Brand = a.Brand.Brand1;
            Model = a.Model.Model1;
            Country = a.Country.Country1;
            Color = a.Color.Color1;
            Transm = a.Transmission.Transmission1;
        }
    }
}
