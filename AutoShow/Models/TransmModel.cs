using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entity;
namespace AutoShow.Models
{
   public class TransmModel
    {

        public int Id { get; set; }
        public string Transmission1 { get; set; }

        public TransmModel() { }
        public TransmModel( Transmission t)
        {
            Id = t.Id;
            Transmission1 = t.Transmission1;
        }
    }
}
