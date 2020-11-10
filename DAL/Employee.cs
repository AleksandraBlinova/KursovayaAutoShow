namespace DAL
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
            User = new HashSet<User>();
        }

        public int Id { get; set; }

        public int Experiance { get; set; }

        public int Salary { get; set; }

        public int RecordNumber { get; set; }

        public int SNILS { get; set; }

        public int HumFK { get; set; }

        public int EmpTypeFK { get; set; }

        public virtual EmpType EmpType { get; set; }

        public virtual Human Human { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> User { get; set; }
    }
}
