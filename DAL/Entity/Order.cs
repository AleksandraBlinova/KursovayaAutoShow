namespace DAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        public int Id { get; set; }

        public int Cost { get; set; }

        public int AutoFK { get; set; }

        public int ClientFK { get; set; }

        public int EmpFK { get; set; }

        public int VechTypeFK { get; set; }

        [Column(TypeName = "date")]
        public DateTime OrderDate { get; set; }

        public int PayTypeFK { get; set; }

        public virtual Automobile Automobile { get; set; }

        public virtual Client Client { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual PayType PayType { get; set; }

        public virtual VehicleEquip VehicleEquip { get; set; }
    }
}
