namespace DAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            Purchase = new HashSet<Purchase>();
        }

        public int Id { get; set; }

        public int Experiance { get; set; }

        public int Salary { get; set; }

        public int RecordNumber { get; set; }

        public int SNILS { get; set; }

        public int EmpTypeFK { get; set; }

        [Required]
        [StringLength(20)]
        public string FCS { get; set; }

        public long Number { get; set; }

        [Required]
        [StringLength(50)]
        public string Address { get; set; }

        public int SerPassport { get; set; }

        public int NumbPassport { get; set; }

        public int GendFK { get; set; }

        [Required]
        [StringLength(20)]
        public string Login { get; set; }

        public int Password { get; set; }

        [Column(TypeName = "date")]
        public DateTime Birthday { get; set; }

        public virtual EmpType EmpType { get; set; }

        public virtual Gender Gender { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Purchase> Purchase { get; set; }
    }
}
