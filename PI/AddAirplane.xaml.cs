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
    /// Логика взаимодействия для AddAirplane.xaml
    /// </summary>
    public partial class AddAirplane : Page
    {
        public AddAirplane()
        {
            InitializeComponent();
        }

        private void ConfimAddAirplane_Click(object sender, RoutedEventArgs e)
        {
            if (AddAirplaneID.Text != "" && AddAirplaneName.Text != "" && EconomClass.Text != "" && BusinessClass.Text != "" && FirstClass.Text != "")
            {
                try
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["MainConnection"].ConnectionString;
                    string query = $"INSERT INTO Airplane (Id,Model,Econom,Business,First) " +
                        $"VALUES ('{AddAirplaneID.Text}', '{AddAirplaneName.Text}', '{EconomClass.Text}', '{BusinessClass.Text}', '{FirstClass.Text}');";


                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(query, connection);
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                    AddAirplaneID.Clear();
                    AddAirplaneName.Clear();
                    EconomClass.Clear();
                    BusinessClass.Clear();
                    FirstClass.Clear();
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
