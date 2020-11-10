using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModels
{
    class ColorModel
    {
        public int Id { get; set; }

        public string Color { get; set; }



        public ColorModel() { }
        public ColorModel(Color c)
        {
            Id = c.Id;
            Color = c.Color1;
        }
    }
}
