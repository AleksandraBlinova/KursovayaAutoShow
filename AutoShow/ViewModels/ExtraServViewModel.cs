using AutoShow.Models;
using AutoShow.View;
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
    public class ExtraServViewModel : INotifyPropertyChanged
    {
        private DBOperations db;
        private ReCommand close; //закрыть окно
        private ReCommand back;
        private bool manager; string EmpFCS;
        public ReCommand Close_Win
        {
            get
            {
                return close ??
                  (close = new ReCommand(obj =>
                  {
                      priceExtraServ.Close();
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
                      priceExtraServ.Close();
                  }));
            }
        }
        public ObservableCollection<ExtraServModel> AllServ { get; set; }

        private PriceExtraServ priceExtraServ;

        public ExtraServViewModel(PriceExtraServ priceExtraServ , bool manager, string EmpFCS)
        {
            db = new DBOperations();

            AllServ = new ObservableCollection<ExtraServModel>(db.GetExtraServ());
            this.priceExtraServ = priceExtraServ;
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