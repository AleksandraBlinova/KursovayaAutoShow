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
    /// Логика взаимодействия для LittleReport.xaml
    /// </summary>
    public partial class LittleReport : Window
    {
        public LittleReport(bool manager, string EmpFCS, int selectedId, string formname)
        {
            InitializeComponent();
            DataContext = new LittleReportViewModel(this, manager, EmpFCS, selectedId, formname);
        }
    }
}
