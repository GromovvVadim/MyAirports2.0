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

namespace PI
{
    /// <summary>
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
        }
        public Menu(string login)
        {
            InitializeComponent();
            Login = login;
        }
        public string Login { get; set; }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void CabinetButton_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Cabinet();
        }

        private void ScheduleButton_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Schedule();
        }

        private void FindButton_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new FindPage();
        }
        private void MyTicketsButton_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new MyTickets();
        }
    }
}
