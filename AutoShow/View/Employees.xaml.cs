﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using AutoShow.ViewModels;
using DAL.Services;
using DAL.ViewModels;

namespace AutoShow
{
    /// <summary>
    /// Логика взаимодействия для Employees.xaml
    /// </summary>
    public partial class Employees : Window
    {
       
      
        public Employees(bool admin)
        {
            InitializeComponent();
            DataContext = new EmpViewModel(this,admin);

        }


    }
}
