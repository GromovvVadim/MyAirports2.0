using System;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace PI
{
    /// <summary>
    /// Логика взаимодействия для Schedule.xaml
    /// </summary>
    public partial class Schedule : Page
    {
        public Schedule()
        {
            InitializeComponent();
        }

        private void FindButton_Click(object sender, RoutedEventArgs e)
        {
            if(FindDatePicker.Text != null)
            {
                try
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["MainConnection"].ConnectionString;
                    string query = $"SELECT Id,DepartCity as 'Depart City',ArriveCity as 'Arrive City',convert(varchar(10),DepartDate,104) as 'DepartDate'," +
                    "convert(varchar(10),ArriveDate,104) as 'ArrivalDate',CAST(DepartTime AS CHAR(5)) as 'Depart Time',CAST(ArriveTime AS CHAR(5)) as 'Arrive Time',AirplaneID as 'Airplane Id',Airline FROM FLIGHT " +
                    $"where convert(varchar(10),DepartDate,104)='{FindDatePicker.Text}'";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        FindDataGrid.ItemsSource = ds.Tables[0].DefaultView;
                    }
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }
            }
        }
    }
}
