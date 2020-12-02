using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entity;

namespace AutoShow.Models
{
    public  class VechTypeModel
    {
        public int Id { get; set; }

        public int HP { get; set; }

        public int Speed { get; set; }
        public string EquipType { get; set; }

        public int TransmFK { get; set; }

        public int ModelFK { get; set; }


        public VechTypeModel() { }
        public VechTypeModel(VehicleEquip v)
        {
            Id = v.Id;
            HP = v.HP;
            Speed = v.Speed;
            EquipType = v.EquipType;
            TransmFK = v.TransmFK;
            ModelFK = v.ModelFK;
        }
    }
}
