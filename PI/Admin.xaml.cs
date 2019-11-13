using System.Windows;
using System.Windows.Input;

namespace PI
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
        }
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

        private void DeleteFlight_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new DeleteFlight();
        }

        private void ChangeFlight_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new ChangeFlight();
        }

        private void AddAirport_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new AddAirport();
        }

        private void AddFlight_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new AddFlight();
        }

        private void AddAirplaneButton_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new AddAirplane();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Main.Content = new AddFlight();
        }
    }
}
