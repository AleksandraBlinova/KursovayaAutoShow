using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoShow.Models
{
   public class CarModel
    {

        public int Id { get; set; }

        public long Price { get; set; }

        public bool Availability { get; set; }

        public int ReleaseYear { get; set; }

        public int ColorFK { get; set; }

        public int PlantFK { get; set; }

        public int ModelFK { get; set; }


        public CarModel() { }
        public CarModel(Automobile a)
        {
            Id = a.Id;
            Price = a.Price;
            Availability = a.Availability;
            ModelFK = a.ModelFK;
            ColorFK = a.ColorFK;
            Price = a.Price;
            ReleaseYear = a.ReleaseYear;
            PlantFK = a.PlantFK;


        }
    }
}
