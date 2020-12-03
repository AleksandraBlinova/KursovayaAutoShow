﻿using AutoShow.ViewModels;
using System;
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

namespace AutoShow.View
{
    /// <summary>
    /// Логика взаимодействия для ThanksForPurch.xaml
    /// </summary>
    public partial class ThanksForPurch : Window
    {
        public ThanksForPurch(bool manager, long cost, string EmpFCS)
        {
            InitializeComponent();
            DataContext = new ThanksBuyViewModel(this, manager, cost, EmpFCS);
        }
    }
}
