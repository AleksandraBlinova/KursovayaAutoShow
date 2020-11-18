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
    public class PurchModel 
    {
        public long Id { get; set; }
        public string EmpFCS { get; set; }
        public string CliFCS { get; set; }

        public string PurchDate { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Plant { get; set; }
        public string Color { get; set; }
        public int ReleaseYear { get; set; }
        public long TotalCost { get; set; }
        public string ExtraServ { get; set; }
        public string PayType { get; set; }
        public string EquipType { get; set; }
        public string Transm { get; set; }




        public PurchModel() { }
        public PurchModel(Purchase purhcase)
        {
            Id = purhcase.Id;
            PurchDate = purhcase.PurchDate.ToShortDateString();
            TotalCost = purhcase.TotalCost;
            EmpFCS = purhcase.Employee.FCS;
            CliFCS = purhcase.Client.FCS;
            Brand = purhcase.Automobile.VehicleEquip.Model.Brand.Brand1;
            Model = purhcase.Automobile.VehicleEquip.Model.Model1;
            ReleaseYear = purhcase.Automobile.ReleaseYear;
            //ExtraServ = purhcase.ExtraServ.ServName;
            PayType = purhcase.PayType.PayType1;
            EquipType = purhcase.Automobile.VehicleEquip.EquipType;
            Transm = purhcase.Automobile.VehicleEquip.Transmission.Transmission1;
            Color = purhcase.Automobile.Color.Color1;
            Plant = purhcase.Automobile.Plant.PlantName;



        }
    }
}
