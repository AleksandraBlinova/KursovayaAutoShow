﻿using AutoShow.Models;
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
    public class AutoViewModel : INotifyPropertyChanged
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
                      MenuManager menuManager  = new MenuManager();
                      menuManager.ShowDialog();
                      automobiles.Close();
                  }));
            }
        }

        public ObservableCollection<AutoModel> Autos { get; set; }

        private Automobiles automobiles;
        public AutoViewModel(Automobiles automobiles)
        {
            db = new DBOperations();

            Autos = new ObservableCollection<AutoModel>(db.GetAllCars());
            this.automobiles = automobiles;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}