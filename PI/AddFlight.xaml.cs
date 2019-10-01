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
    /// Логика взаимодействия для AddFlight.xaml
    /// </summary>
    public partial class AddFlight : Page
    {
        public AddFlight()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //UpdateItems();
            
        }
        private void UpdateItems()
        {
            DepartCityComboBox.Items.Clear();
            ArrivalCityComboBox.Items.Clear();
            string connectionString = ConfigurationManager.ConnectionStrings["MainConnection"].ConnectionString;
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd =  new SqlCommand();
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT * FROM Airport";
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        DepartCityComboBox.Items.Add(dr["City"]);
                        ArrivalCityComboBox.Items.Add(dr["City"]);

                    }
                    dr.Close();
                    cmd.CommandText = "SELECT * FROM Airplane";
                    SqlDataReader dr1 = cmd.ExecuteReader();
                    while (dr1.Read())
                    {
                        AiplaneIdComboBox.Items.Add(dr1["Id"]);
                    }
                    dr1.Close();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
            UpdateItems();
            
        }

        private void ConfimAddFlight_Click(object sender, RoutedEventArgs e)
        {
            if (DepartCityComboBox.Text != "" && ArrivalCityComboBox.Text != "" && DepartDate.Text != "" && ArrivalDate.Text != "" &&
                DepartTimePicker.Text != "" && ArrivalTimePicker.Text != "" && AiplaneIdComboBox.Text != "" && AirlineBox.Text != "")
            {
                try
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["MainConnection"].ConnectionString;
                    string query = $"INSERT INTO Flight (DepartCity,ArriveCity,DepartDate,ArriveDate,DepartTime,ArriveTime,AirplaneID,Airline) " +
                        $"VALUES ('{DepartCityComboBox.Text}','{ArrivalCityComboBox.Text}','{DepartDate.Text}','{ArrivalDate.Text}','{DepartTimePicker.Text}','{ArrivalTimePicker.Text}','{AiplaneIdComboBox.Text}','{AirlineBox.Text}')";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(query, connection);
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                    AirlineBox.Clear();
                    DepartCityComboBox.Text = "";
                    ArrivalCityComboBox.Text = "";
                    DepartDate.Text = "";
                    ArrivalDate.Text = "";
                    DepartTimePicker.Text = "";
                    ArrivalTimePicker.Text = "";
                    AiplaneIdComboBox.Text = "";
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
