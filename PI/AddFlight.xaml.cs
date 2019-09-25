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
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=testdb;Integrated Security=True";
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
            if(DepartMinutsComboBox.Items.Count == 0)
            {
                for (int i = 0; i < 60; i++)
                {
                    if (i.ToString().Length == 1)
                    {
                        ArrivalHourComboBox.Items.Add("0" + i.ToString());
                        DepartHourComboBox.Items.Add("0" + i.ToString());
                    }
                    else
                    {
                        DepartMinutsComboBox.Items.Add(i.ToString());
                        ArrivalMinutsComboBox.Items.Add(i.ToString());
                    }
                }
                ArrivalTimeComboBox.Items.Add("AM");
                ArrivalTimeComboBox.Items.Add("PM");
                DepartTimeComboBox.Items.Add("AM");
                DepartTimeComboBox.Items.Add("PM");
            }
            for (int i = 0; i < 13; i++)
            {
                if(i.ToString().Length == 1)
                {
                    ArrivalHourComboBox.Items.Add("0" + i.ToString());
                    DepartHourComboBox.Items.Add("0" + i.ToString());
                }
                else
                {
                    ArrivalHourComboBox.Items.Add(i.ToString());
                    DepartHourComboBox.Items.Add(i.ToString());
                }
            }
        }

        private void ConfimAddFlight_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
