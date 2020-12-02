using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entity;

namespace AutoShow.Models
{
   public  class ModelsModel
    {


        public int Id { get; set; }
        public string Model { get; set; }

        public ModelsModel() { }
        public ModelsModel(Model model)
        {
            Id = model.Id;
            Model = model.Model1;
        }
    }
}
