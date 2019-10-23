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
    /// Логика взаимодействия для Cabinet.xaml
    /// </summary>
    public partial class Cabinet : Page
    {
        public Cabinet()
        {
            InitializeComponent();
        }
        public Cabinet(string login)
        {
            InitializeComponent();
            Login = login;
        }
        public string Login { get; set; }
        private void Password_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Old_Password.Text != "" && Password.Text != "" && Password_check.Text != "")
            {
                if (Password.Text == Password_check.Text)
                {
                    try
                    {
                        string connectionString = ConfigurationManager.ConnectionStrings["MainConnection"].ConnectionString;
                        string query = $"Update Customer Set Password = '{Password.Text}'Where Login = '{Login}'";

                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            SqlCommand command = new SqlCommand(query, connection);
                            command.ExecuteNonQuery();
                            connection.Close();
                        }
                        Old_Password.Clear();
                        Password.Clear();
                        Password_check.Clear();
                    }
                    catch (Exception ee)
                    {
                        MessageBox.Show(ee.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Перевірте поля");
                }
            }
            else
            {
                MessageBox.Show("Заповніть всі поля");
            }
        }

        private void Email_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Old_Email.Text != "" && Email.Text != "" && Email_check.Text != "")
            {
                if (Email.Text == Email_check.Text)
                {
                    try
                    {
                        string connectionString = ConfigurationManager.ConnectionStrings["MainConnection"].ConnectionString;
                        string query = $"Update Customer Set Email = '{Email.Text}'Where Login = '{Login}'";


                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            SqlCommand command = new SqlCommand(query, connection);
                            command.ExecuteNonQuery();
                            connection.Close();
                        }
                        Old_Password.Clear();
                        Password.Clear();
                        Password_check.Clear();
                    }
                    catch (Exception ee)
                    {
                        MessageBox.Show(ee.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Перевірте поля");
                }
            }
            else
            {
                MessageBox.Show("Заповніть всі поля");
            }
        }
    }
}
