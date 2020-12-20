using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entity;

namespace AutoShow.Models
{
   public class OrderModel
    {
        public int Id { get; set; }

        public string EmpFCS { get; set; }
        public string CliFCS { get; set; }
        public string EquipType { get; set; }
        public string OrderDate { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Plant { get; set; }
        public string Color { get; set; }
        public int ReleaseYear { get; set; }
        public int Cost { get; set; }
        public string Transm { get; set; }
        public string TypePay { get; set; }



        public OrderModel() { }
        public OrderModel(DAL.Entity.Order order)
        {
            Id = order.Id;
            OrderDate = order.OrderDate.ToShortDateString();
            Cost = order.Cost;
            EmpFCS = order.Employee.FCS;
            CliFCS = order.Client.FCS;
            Brand = order.Automobile.Model.Brand.Brand1;
            Model = order.Automobile.Model.Model1;
            ReleaseYear = order.Automobile.ReleaseYear;
            Transm = order.VehicleEquip.Transmission.Transmission1;
            Color = order.Automobile.Color.Color1;
            Plant = order.Automobile.Plant.PlantName;
            EquipType = order.VehicleEquip.EquipType;
            TypePay = order.PayType.PayType1;

        }
    }
}
