using AutoShow.Models;
using AutoShow.View;
using DAL.Entity;
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
using System.Windows.Data;

namespace AutoShow.ViewModels
{
    public class AutoViewModel : INotifyPropertyChanged
    {
        private DBOperations db;
        private ReCommand close; //закрыть окно
        private ReCommand back;
        private ReCommand buy;
        private bool manager;
        private string EmpFCS;
        public ReCommand Close_Win
        {
            get
            {
                return close ??
                  (close = new ReCommand(obj =>
                  {
                      automobiles.Close(); 
                  }));
            }
        }
        public ReCommand Back
        {
            get
            {
                return back ??
                  (back = new ReCommand(obj =>
                  {
                      MenuManager menuManager = new MenuManager(manager, EmpFCS);
                      menuManager.ShowDialog();
                      automobiles.Close();
                  }));
            }
        }
        public ReCommand Buy
        {
            get
            {
                return buy ??
                  (buy = new ReCommand(obj =>
                  {
                      BuyAuto buyAuto  = new BuyAuto(manager, EmpFCS);
                      buyAuto.ShowDialog();
                      automobiles.Close();
                  }));
            }
        }

        private ReCommand delete;
        public ReCommand Delete
        {
            get
            {
                return delete ??
                  (delete = new ReCommand(obj =>
                  {
                      AutoModel row = (AutoModel)automobiles.DataGCars.SelectedItems[0];
                      ObservableCollection<AutoModel> data = (ObservableCollection<AutoModel>)automobiles.DataGCars.ItemsSource;
                      data.Remove(row);
                  }));
            }
        }

        private ReCommand changeAvail;
        public ReCommand ChangeAvail
        {
            get
            {
                return changeAvail ??
                  (changeAvail = new ReCommand(obj =>
                  {
                      AutoModel row = (AutoModel)automobiles.DataGCars.SelectedItems[0];
                      db.ChangeAvail(row);
                      

                  }));
            }
        }

        public ObservableCollection<AutoModel> Autos { get; set; }

        private Automobiles automobiles;
        public AutoViewModel(Automobiles automobiles, bool manager, string EmpFCS)
        {
            db = new DBOperations();

            Autos = new ObservableCollection<AutoModel>(db.GetAllCars());
            this.automobiles = automobiles;
            this.manager = manager;
            this.EmpFCS = EmpFCS;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
