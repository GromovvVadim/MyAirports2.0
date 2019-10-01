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
    /// Логика взаимодействия для DeleteFlight.xaml
    /// </summary>
    public partial class DeleteFlight : Page
    {
        public DeleteFlight()
        {
            InitializeComponent();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MainConnection"].ConnectionString;
                string query = "SELECT * FROM FLIGHT";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    DeleteDateGrid.ItemsSource = ds.Tables[0].DefaultView;
                }
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void ConfirmDeleteFlightButton_Click(object sender, RoutedEventArgs e)
        {
            if (DeleteDateGrid.SelectedItem != null)
            {
                try
                {
                    DataRowView row = DeleteDateGrid.SelectedItem as DataRowView;
                    string connectionString = ConfigurationManager.ConnectionStrings["MainConnection"].ConnectionString;
                    string query = $"DELETE FROM FLIGHT WHERE ID = '{row.Row.ItemArray[0].ToString()}'";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(query, connection);
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                    UpdateButton_Click(sender,e);
                }
                catch(Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }
            }
        }
    }
}
