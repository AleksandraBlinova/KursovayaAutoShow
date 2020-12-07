using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entity;

namespace AutoShow.Models
{
   public  class ExtraServModel
    {

        public int Id { get; set; }

        public string ServName { get; set; }

        public int? ServCost { get; set; }

        public ExtraServModel() { }
        public ExtraServModel(ExtraServ serv )
        {
            Id = serv.Id;
            ServName = serv.ServName;
            ServCost = serv.ServCost;
        }
    }
}
