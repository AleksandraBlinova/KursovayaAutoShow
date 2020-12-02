using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entity;

namespace AutoShow.Models
{
    public class BrandModel
    {
        public int Id { get; set; }

        public string Brand1 { get; set; }

        public BrandModel() { }
        public BrandModel(Brand brand)
        {
            Id = brand.Id;
            Brand1 = brand.Brand1;
        }
    }
}
