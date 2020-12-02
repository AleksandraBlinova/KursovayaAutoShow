﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entity;

namespace AutoShow.Models
{
    public class ColorModel
    {
        public int Id { get; set; }

        public string Color1 { get; set; }
        public ColorModel() { }
        public ColorModel(Color c)
        {
            Id = c.Id;
            Color1 = c.Color1;
        }
    }
}
