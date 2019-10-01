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
    /// Логика взаимодействия для AddAirport.xaml
    /// </summary>
    public partial class AddAirport : Page
    {
        public AddAirport()
        {
            InitializeComponent();
        }

        private void ConfimAddAirport_Click(object sender, RoutedEventArgs e)
        {
            if(AddCityBox.Text!=""&& AddCountryBox.Text != "" && AddIATABox.Text != "")
            {
                try
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["MainConnection"].ConnectionString;
                    string query = $"INSERT INTO Airport (city,country,IATA) VALUES ('{AddCityBox.Text}', '{AddCountryBox.Text}', '{AddIATABox.Text}');";


                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(query, connection);
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                    AddCityBox.Clear();
                    AddCountryBox.Clear();
                    AddIATABox.Clear();
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }
            }
            else
            {
                MessageBox.Show("Something wrong");
            }
        }
    }
}
