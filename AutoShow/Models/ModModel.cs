using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entity;

namespace AutoShow.Models
{
    public class ModModel
    {
        public int Id { get; set; }
        public string Model1 { get; set; }
        public int BrandFK { get; set; }

        public ModModel() { }
        public ModModel(Model m)
        {
            Id = m.Id;
            Model1 = m.Model1;
            BrandFK = m.BrandFK;
        }
    }
}
