using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using DAL.Entity;
using DAL.Services;

namespace AutoShow.ViewModels
{
    public class AutorizationViewModel : INotifyPropertyChanged
    {
        private ReCommand close;
         string EmpFCS;
        public ReCommand Close_Win
        {
            get
            {
                return close ??
                  (close = new ReCommand(obj =>
                  {
                      authorization.Close();
                  }));
            }
        }
        private DBContext AutoShow;
        private string login;
        public string Login
        {
            get { return login; }
            set
            {
                login = value;
                OnPropertyChanged("Login");
            }
        }
        private ReCommand entrance; //вход
        public ReCommand Entrance
        {
            
            get
            {
                return entrance ??
                  (entrance = new ReCommand(obj =>
                  {
                      var passwordBox = obj as PasswordBox;
                      if (passwordBox == null || passwordBox.Password == "")
                          return;
                      var _password = passwordBox.Password;
                      Employee employee  = AutoShow.Employee.Where(i => i.Login == login).SingleOrDefault();
                      if (employee != null && employee.Password.ToString() == _password)
                      {
                          bool manager = false;
                          EmpFCS = employee.FCS;
                          if (employee.EmpType.EmpType1 == "Менеджер")
                          {

                              manager = true;
                              MenuManager menuMan = new MenuManager(manager, EmpFCS);
                              authorization.Close();
                              menuMan.Show(); //открываем меню (менеджера)   

                          }
                          else
                          {
                              manager = false;
                              MenuAdministr menuAdm = new MenuAdministr(manager);
                              authorization.Close();
                              menuAdm.Show(); //открываем меню (администрат) 
                          }
                      }
                      else MessageBox.Show("Логин или пароль введены неверно!");
                  }));
            }
        }



        private Authorization authorization; 
        public AutorizationViewModel(Authorization authorization)
        {
            this.authorization = authorization;
            AutoShow = new DBContext();
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
       
}
