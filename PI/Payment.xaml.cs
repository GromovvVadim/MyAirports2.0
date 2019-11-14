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
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace PI
{
    /// <summary>
    /// Логика взаимодействия для Payment.xaml
    /// </summary>
    public partial class Payment : Window
    {
        public Payment()
        {
            InitializeComponent();
        }
        public Payment(string Login)
        {
            this.Login = Login;
            InitializeComponent();
        }
        public string Login { get; set; }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        private void Pay_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MainConnection"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    foreach (var query in Class1.ListOfQueries)
                    {
                        SqlCommand command = new SqlCommand(query, connection);
                        command.ExecuteNonQuery();
                    }
                    string query1 = $"INSERT INTO Payment (CardNumber,CardType,CardOwner,ExpirationDate,CVC,Sum,Login) " +
                        $"VALUES ('{CardNumber.Text}','{CardType.Text}','{CardOwner.Text}',CONVERT(date, '{ExpirationDate.Text}', 104),'{Cvc.Text}','{Class1.Sum}','{Login}')";
                    SqlCommand command1 = new SqlCommand(query1, connection);
                    command1.ExecuteNonQuery();
                    connection.Close();
                    this.Visibility = Visibility.Hidden;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TotalSum.Text = $"${Class1.Sum}";
        }
    }
}
