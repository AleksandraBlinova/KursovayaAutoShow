namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Human")]
    public partial class Human
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Human()
        {
            Client = new HashSet<Client>();
            Employee = new HashSet<Employee>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string FCS { get; set; }

        [Column(TypeName = "date")]
        public DateTime Birthday { get; set; }

        public long Number { get; set; }

        [Required]
        [StringLength(50)]
        public string Address { get; set; }

        public int SerPassport { get; set; }

        public int NumbPassport { get; set; }

        public int GendFK { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Client> Client { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employee> Employee { get; set; }

        public virtual Gender Gender { get; set; }
    }
}
