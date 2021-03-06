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
    /// Логика взаимодействия для ChooseCustEmp.xaml
    /// </summary>
    public partial class ChooseCustEmp : Window
    {
        public ChooseCustEmp(int modelid, long cost,int color, int equip, bool manager, string EmpFCS, string transm)
        {
            InitializeComponent();
            DataContext = new ChooseViewModel(this, modelid, cost, color, equip, manager, EmpFCS, transm);
        }
    }
}
