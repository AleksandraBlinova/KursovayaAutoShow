namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VehicleEquip")]
    public partial class VehicleEquip
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VehicleEquip()
        {
            Automobile = new HashSet<Automobile>();
        }

        public int Id { get; set; }

        public int HP { get; set; }

        public int Speed { get; set; }

        [Required]
        [StringLength(20)]
        public string EquipType { get; set; }

        public int ModelFK { get; set; }

        public int TransmFK { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Automobile> Automobile { get; set; }

        public virtual Model Model { get; set; }

        public virtual Transmission Transmission { get; set; }
    }
}
