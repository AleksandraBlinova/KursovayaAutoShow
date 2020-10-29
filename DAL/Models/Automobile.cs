namespace DAL.Entities
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
            Purchase = new HashSet<Purchase>();
        }

        public int Id { get; set; }

        public long Price { get; set; }

        public bool Availability { get; set; }

        public int ReleaseYear { get; set; }

        [Required]
        [StringLength(20)]
        public string Plant { get; set; }

        public int CountryFK { get; set; }

        public int ColorFK { get; set; }

        public int ModelFK { get; set; }

        public int BrandFK { get; set; }

        public int TransmFK { get; set; }

        public virtual Brand Brand { get; set; }

        public virtual Color Color { get; set; }

        public virtual Country Country { get; set; }

        public virtual Model Model { get; set; }

        public virtual Transmission Transmission { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Purchase> Purchase { get; set; }
    }
}
