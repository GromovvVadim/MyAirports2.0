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
    /// Логика взаимодействия для Personal_Informariton.xaml
    /// </summary>
    public partial class Personal_Informariton : Window
    {
        public Personal_Informariton()
        {
            InitializeComponent();
        }
        public Personal_Informariton(string Login)
        {
            InitializeComponent();
            this.Login = Login;
        }
        public string Login { get; set; }
        public int IdFlight { get; set; }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }

        private void AddPassenger_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
