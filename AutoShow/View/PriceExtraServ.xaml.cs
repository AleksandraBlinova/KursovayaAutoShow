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
using AutoShow.ViewModels;

namespace AutoShow.View
{
    /// <summary>
    /// Логика взаимодействия для PriceExtraServ.xaml
    /// </summary>
    public partial class PriceExtraServ : Window
    {
        public PriceExtraServ(bool manager, string EmpFCS)
        {
            InitializeComponent();
            DataContext = new ExtraServViewModel(this, manager, EmpFCS);
        }
    }
}
