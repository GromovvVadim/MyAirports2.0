using System;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Configuration;


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
