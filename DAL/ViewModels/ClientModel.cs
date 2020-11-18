using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModels
{
   public  class ClientModel
    {
        public int Id { get; set; }
        public string FCS { get; set; }
        public DateTime Birthday { get; set; }
        public long Number { get; set; }
        public string Address { get; set; }

        public int SerPassport { get; set; }

        public int NumbPassport { get; set; }

        public string Gend { get; set; }

        public ClientModel() { }
        public ClientModel(Client c)
        {
            Id = c.Id;
            FCS = c.Human.FCS;
            Birthday = c.Human.Birthday;
            Number = c.Human.Number;
            Address = c.Human.Address;
            SerPassport = c.Human.SerPassport;
            NumbPassport = c.Human.NumbPassport;
            Gend = c.Human.Gender.Gender1;

        }

    }
}
