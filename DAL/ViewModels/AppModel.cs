using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DAL.ViewModels;
using DAL;
using DAL.Services;

namespace DAL.ViewModels
{
    class AppModel : INotifyCollectionChanged
    {
        public ObservableCollection<Purchase> Purchases { get; set; }
        public AppModel()
        {


            //Purchases = new ObservableCollection<Purchase>
            //{

            //}


        }
        public event PropertyChangedEventHandler PropertyChanged;
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }


    }
}
