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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace PI
{
    /// <summary>
    /// Логика взаимодействия для FindPage.xaml
    /// </summary>
    public partial class FindPage : Page
    {
        public FindPage()
        {
            InitializeComponent();

        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DepartAirport.Items.Clear();
            ArrivalAirport.Items.Clear();
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=testdb;Integrated Security=True";
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT DISTINCT City FROM Airport";
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        DepartAirport.Items.Add(dr["City"]);
                        ArrivalAirport.Items.Add(dr["City"]);

                    }
                    dr.Close();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
