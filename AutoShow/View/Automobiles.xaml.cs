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
using AutoShow.ViewModels;

namespace AutoShow
{
    /// <summary>
    /// Логика взаимодействия для Automobiles.xaml
    /// </summary>
    public partial class Automobiles : Window
    {
        
        public Automobiles(bool manager, string EmpFCS)
        {
            InitializeComponent();
            DataContext = new AutoViewModel(this,manager, EmpFCS);

        }


        
    }
    
}
