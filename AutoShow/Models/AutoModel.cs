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
    public class AutoModel : IEquatable<AutoModel>
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
          Brand = a.Model.Brand.Brand1;
          Model = a.Model.Model1;
          Color = a.Color.Color1;
          Price = a.Price;
          Transm = a.Model.VehicleEquip.Where(i => i.ModelFK == a.ModelFK).FirstOrDefault().Transmission.Transmission1;
          HP = a.Model.VehicleEquip.Where(i => i.ModelFK == a.ModelFK).FirstOrDefault().HP;
          Speed = a.Model.VehicleEquip.Where(i => i.ModelFK == a.ModelFK).FirstOrDefault().Speed;
          ReleaseYear = a.ReleaseYear;
          Plant = a.Plant.PlantName;


        }

        public bool Equals(AutoModel other)
        {
            //Check whether the compared object is null.
            if (Object.ReferenceEquals(other, null)) return false;

            //Check whether the compared object references the same data.
            if (Object.ReferenceEquals(this, other)) return true;

            //Check whether the products' properties are equal.
            return Id.Equals(other.Id) && Model.Equals(other.Model);
        }
        // If Equals() returns true for a pair of objects
        // then GetHashCode() must return the same value for these objects.

        public override int GetHashCode()
        {

            //Get hash code for the Name field if it is not null.
            int hashProductModel = Model == null ? 0 : Model.GetHashCode();

            //Get hash code for the Code field.
            int hashProductId = Id.GetHashCode();

            //Calculate the hash code for the product.
            return hashProductModel ^ hashProductId;
        }
    }
}
