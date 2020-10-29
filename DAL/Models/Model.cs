namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Model")]
    public partial class Model
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Model()
        {
            Automobile = new HashSet<Automobile>();
        }

        public int Id { get; set; }

        [Column("Model")]
        [Required]
        [StringLength(20)]
        public string Model1 { get; set; }

        public int BrandFK { get; set; }

        public int? VechTypeFK { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Automobile> Automobile { get; set; }

        public virtual Brand Brand { get; set; }

        public virtual VehicleEquip VehicleEquip { get; set; }
    }
}
