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

namespace AutoShow.View
{
    /// <summary>
    /// Логика взаимодействия для TypePay.xaml
    /// </summary>
    public partial class TypePay : Window
    {
        public TypePay(int modelid, long cost, int color, int eqip, int client, int emp, bool manager)
        {
            InitializeComponent();
            DataContext = new TypePayViewModel(this, modelid, cost, color, eqip, client, emp, manager);
        }
    }
}
