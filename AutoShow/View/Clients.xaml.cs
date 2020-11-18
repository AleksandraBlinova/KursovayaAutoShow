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
using System.Data.SqlClient;
using System.Windows.Navigation;
using System.Configuration;
using System.Data;
using DAL.ViewModels;
using DAL.Services;
using DAL;
using AutoShow.ViewModels;

namespace AutoShow
{
    /// <summary>
    /// Логика взаимодействия для Clients.xaml
    /// </summary>
    public partial class Clients : Window
    {
        
        public Clients(bool manager)
        {
            InitializeComponent();
            DataContext = new CliViewModel(this, manager);


        }



    }
}
