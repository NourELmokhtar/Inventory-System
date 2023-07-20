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

namespace ElC
{
    /// <summary>
    /// Interaction logic for LoginAsKashier.xaml
    /// </summary>
    public partial class LoginAsKashier : UserControl
    {
        public LoginAsKashier()
        {
            InitializeComponent();
        }

        private void Customer_n_Click(object sender, RoutedEventArgs e)
        {
            ShowContent.Content = new Customer();
        }

        private void btn_home_Click(object sender, RoutedEventArgs e)
        {
            ShowContent.Content = new StartPage();
        }

        private void btnlogout_Clickk_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow = new MainWindow();

            Application.Current.MainWindow.Show();
            Window.GetWindow(this).Close();
        }

        private void btn_recovery_Click(object sender, RoutedEventArgs e)
        {
            ShowContent.Content = new Return();
        }

        private void Founding_Click(object sender, RoutedEventArgs e)
        {
            ShowContent.Content = new Founding();
        }
    }
}
