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
    public class CliViewModel : INotifyPropertyChanged
    {
        private DBOperations db;
        private ReCommand close; //закрыть окно
        private ReCommand back;
        public ReCommand Close_Win
        {
            get
            {
                return close ??
                  (close = new ReCommand(obj =>
                  {
                      clients.Close();
                  }));
            }
        }
        //public ReCommand Back
        //{
        //    get
        //    {
        //        return back ??
        //          (back = new ReCommand(obj =>
        //          {
        //              MenuManager menuManager = new MenuManager();
        //              menuManager.ShowDialog();
        //              clients.Close();
        //          }));
        //    }
        //}
        public ObservableCollection<ClientModel> clies { get; set; }

        private Clients clients;
        public CliViewModel(Clients clients)
        {
            db = new DBOperations();

            clies = new ObservableCollection<ClientModel>(db.GetAllClients());
            this.clients = clients;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    
    }
}
