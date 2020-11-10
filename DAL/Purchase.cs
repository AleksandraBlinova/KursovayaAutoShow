namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Purchase")]
    public partial class Purchase
    {
        public long Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime PurchDate { get; set; }

        public long TotalCost { get; set; }

        public int AutoFK { get; set; }

        public int ClientFK { get; set; }

        public int? ExtraSevFK { get; set; }

        public int PayTypeFK { get; set; }

        public virtual Automobile Automobile { get; set; }

        public virtual Client Client { get; set; }

        public virtual ExtraServ ExtraServ { get; set; }

        public virtual PayType PayType { get; set; }
    }
}
