using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entity;

namespace AutoShow.Models
{
    public class TransmissionModel
    {
        public int Id { get; set; }
        public string Transmission1 { get; set; }
        
        
        
        public TransmissionModel() { }
        public TransmissionModel(Transmission transmission)
        {
            Id = transmission.Id;
            Transmission1 = transmission.Transmission1;
        }
    }
}
