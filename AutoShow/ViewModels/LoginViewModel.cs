using DAL.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AutoShow.ViewModels
{
   public class LoginViewModel: INotifyPropertyChanged
    {

        private ReCommand close; //закрыть окно
        public ReCommand Close_Win
        {
            get
            {
                return close ??
                  (close = new ReCommand(obj =>
                  {
                      login.Close(); //закрыли текущее окно Login
                  }));
            }
        }


        private ReCommand chooseuser; //выбрать пользователя
        public ReCommand Choose_User
        {
            get
            {
                return chooseuser ??
                  (chooseuser = new ReCommand(obj =>
                  {
                      
                      Authorization authorization  = new Authorization();
                      authorization.ShowDialog(); //будем открывать окно Авторизации
                      login.Close();
                  }));
            }
        }




        private Login login; 
        public LoginViewModel(Login login)
        {
            this.login = login;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
