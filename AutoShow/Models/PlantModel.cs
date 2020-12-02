using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entity;

namespace AutoShow.Models
{
    public class PlantModel
    {
        public int Id { get; set; }
        public string PlantName { get; set; }

        public PlantModel() { }
        public PlantModel(Plant p)
        {
            Id = p.Id;
            PlantName = p.PlantName;
           
        }
    }
}
