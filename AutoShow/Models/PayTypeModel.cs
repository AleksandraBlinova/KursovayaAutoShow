using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoShow.Models
{
   public class PayTypeModel
    {
        public int Id { get; set; }
        public string PayType { get; set; }

        public PayTypeModel() { }
        public PayTypeModel(PayType payType )
        {
            Id = payType.Id;
            PayType = payType.PayType1;
        }
    }
}
