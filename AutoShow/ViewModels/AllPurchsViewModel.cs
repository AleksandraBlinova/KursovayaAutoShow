﻿using AutoShow.Models;
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

namespace AutoShow.ViewModels
{
    public class AllPurchsViewModel : INotifyPropertyChanged
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
                      purchases.Close();
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
        //              purchases.Close();
        //          }));
        //    }
        //}
        public ObservableCollection<PurchModel> AllPurchs { get; set; }

        private Purchases purchases;
        public AllPurchsViewModel(Purchases purchases )
        {
            db = new DBOperations();

            AllPurchs = new ObservableCollection<PurchModel>(db.GetAllPurchs());
            this.purchases = purchases;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    
    }
}
