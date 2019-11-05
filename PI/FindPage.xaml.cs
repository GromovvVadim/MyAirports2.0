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
            CountAdult.SelectedIndex = 0;
            CountChild.SelectedIndex = 0;
            CountInfant.SelectedIndex = 0;
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

        private void SearchFlights_Click(object sender, RoutedEventArgs e)
        {
            if(DepartAirport.Text != "" && ArrivalAirport.Text != "" && DatePicker.Text != "")
            {
                try
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["MainConnection"].ConnectionString;
                    string query = $"SELECT Id,DepartCity,ArriveCity,convert(varchar(10),DepartDate,104) as 'DepartDate'," +
                        $"convert(varchar(10),ArriveDate,104) as 'ArrivalDate',CAST(DepartTime AS CHAR(5)) as 'DepartTime',CAST(ArriveTime AS CHAR(5)) as 'ArriveTime',AirplaneID as 'AirplaneId',Airline FROM FLIGHT " +
                        $"where DepartCity = '{DepartAirport.Text}' AND ArriveCity = '{ArrivalAirport.Text}' and convert(varchar(10),DepartDate,104) = '{Convert.ToDateTime(DatePicker.Text).ToString("dd.MM.yyyy")}'";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGrid.ItemsSource = ds.Tables[0].DefaultView;
                    }
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }
            }
            else
            {
                MessageBox.Show("Заповніть всі поля");
            }
        }

        private void ReserveTicket_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                try
                {
                    DataRowView row = dataGrid.SelectedItem as DataRowView;
                    PersonalInformation personalInformationWindow = new PersonalInformation();
                    this.Visibility = Visibility.Hidden;
                    personalInformationWindow.Show();
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }
            }
        }
    }
}
