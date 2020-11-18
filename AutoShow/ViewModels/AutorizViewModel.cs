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
    public class AutorizViewModel : INotifyPropertyChanged
    {
        private ReCommand close; //закрыть окно
        public ReCommand Close_Win
        {
            get
            {
                return close ??
                  (close = new ReCommand(obj =>
                  {
                      authorization.Close(); //закрыли текущее окно Autorization
                  }));
            }
        }


       




        private Authorization authorization;
        public AutorizViewModel(Authorization authorization)
        {
            this.authorization = authorization;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }


    }
}
