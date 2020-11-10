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
using DAL.ViewModels;
using DAL.Services;
using AutoShow.ViewModels;

namespace AutoShow.View
{
    /// <summary>
    /// Логика взаимодействия для Purchases.xaml
    /// </summary>
    public partial class Purchases : Window
    {

       
            public Purchases()
            {
                InitializeComponent();
            DataContext = new AllPurchsViewModel(this);
        }


    }
    
}
