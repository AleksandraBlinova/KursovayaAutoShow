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


namespace AutoShow
{
    /// <summary>
    /// Логика взаимодействия для Automobiles.xaml
    /// </summary>
    public partial class Automobiles : Window
    {
        public Automobiles()
        {
            InitializeComponent();
            //bindgatadrid();

            
        }

        //private void bindgatadrid()
        //{
        //    SqlConnection con = new SqlConnection();
        //    con.ConnectionString = ConfigurationManager.ConnectionStrings["AutoShow"].ConnectionString;
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandText = "Select * from [Automobile]";
        //    cmd.Connection = con;
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataTable Autdt = new DataTable("Automobile");
        //    da.Fill(Autdt);
        //    Cars.ItemsSource = Autdt.DefaultView;


        //}
    }
    
}
