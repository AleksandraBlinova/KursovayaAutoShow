using AutoShow.ViewModels;
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

namespace AutoShow
{
    /// <summary>
    /// Логика взаимодействия для MenuAdministr.xaml
    /// </summary>
    public partial class MenuAdministr : Window
    {
        public MenuAdministr()
        {
            InitializeComponent();
            DataContext = new AdminViewModel(this);
        }

        private void TreeViewItem_Collapsed(object sender, RoutedEventArgs e)
        {

        }

       
    }
}
