using AutoShow.Models;
using DAL.Services;
using DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AutoShow.ViewModels
{
    public class EmpViewModel : INotifyPropertyChanged
    {
        private DBOperations db;
        private ReCommand close; //закрыть окно
        public ReCommand Close_Win
        {
            get
            {
                return close ??
                  (close = new ReCommand(obj =>
                  {
                      employees.Close();
                  }));
            }
        }

        public ObservableCollection<EmployeeModel> emps { get; set; }

        private Employees employees ;
        public EmpViewModel(Employees employees )
        {
            db = new DBOperations();

            emps = new ObservableCollection<EmployeeModel>(db.GetAllEmps());
            this.employees = employees;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    

    }
}
