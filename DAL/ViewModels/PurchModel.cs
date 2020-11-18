using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModels
{
    public class PurchModel : INotifyPropertyChanged
    {

        public string FCS;
        public int SerPassport;
        public int NumbPassport;

        public string fcs
        {
            get { return FCS; }
            set
            {
                FCS = value;
                OnPropertyChanged("FCS");
            }
        }
        public int serpassport
        {
            get { return SerPassport; }
            set
            {
                SerPassport = value;
                OnPropertyChanged("SerPassport");
            }
        }
        public int numpassport
        {
            get { return NumbPassport; }
            set
            {
                NumbPassport = value;
                OnPropertyChanged("NumbPassport");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Purchase> AllPurchs { get; set; }
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
