using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModels
{
  public  class EmployeeModel
    {
        public int Id { get; set; }

        public int Experiance { get; set; }

        public int Salary { get; set; }

        public int RecordNumber { get; set; }

        public int SNILS { get; set; }

        public string FCS { get; set; }
        public DateTime Birthday { get; set; }
        public long Number { get; set; }
        public string Address { get; set; }

        public int SerPassport { get; set; }

        public int NumbPassport { get; set; }

        public string Gend { get; set; }
        public string EmpType { get; set; }

        public EmployeeModel() { }
        public EmployeeModel(Employee employee)
        {
            Id = employee.Id;
            FCS = employee.Human.FCS;
            Birthday = employee.Human.Birthday;
            Number = employee.Human.Number;
            Address = employee.Human.Address;
            SerPassport = employee.Human.SerPassport;
            NumbPassport = employee.Human.NumbPassport;
            Gend = employee.Human.Gender.Gender1;
            EmpType = employee.EmpType.EmpType1;
            RecordNumber = employee.RecordNumber;
            Salary = employee.Salary;
            SNILS = employee.SNILS;
            Experiance = employee.Experiance;

        }
    }
}
