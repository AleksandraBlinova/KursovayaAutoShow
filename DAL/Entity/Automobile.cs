namespace DAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Automobile")]
    public partial class Automobile
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Automobile()
        {
            Order = new HashSet<Order>();
            Purchase = new HashSet<Purchase>();
        }

        public int Id { get; set; }

        public long Price { get; set; }

        public bool Availability { get; set; }

        public int ReleaseYear { get; set; }

        public int ColorFK { get; set; }

        public int PlantFK { get; set; }

        public int ModelFK { get; set; }

        public virtual Color Color { get; set; }

        public virtual Model Model { get; set; }

        public virtual Plant Plant { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Order { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Purchase> Purchase { get; set; }
    }
}
