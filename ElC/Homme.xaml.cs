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
    /// Interaction logic for Homme.xaml
    /// </summary>
    public partial class Homme : UserControl
    {
        public Homme()
        {
            InitializeComponent();
        
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;

        }

        //private void PackIconMaterial_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        //{
        //    ShowContent.Content = new Supplier();
        //}

        //private void PackIconMaterial_MouseDoubleClick_2(object sender, MouseButtonEventArgs e)
        //{
        //    ShowContent.Content= new Customer();
        //}

        //private void PackIconMaterial_MouseDoubleClick_3(object sender, MouseButtonEventArgs e)
        //{
        //    ShowContent.Content = new Report2();

        //}

        //private void PackIconMaterial_MouseDoubleClick_6(object sender, MouseButtonEventArgs e)
        //{
        //    ShowContent.Content = new NewSupplier();

        //}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ShowContent.Content=new Statistics();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ShowContent.Content = new NewSupplier();

        }

        private void SupplierProducts_Click(object sender, RoutedEventArgs e)
        {
            ///
            ShowContent.Content = new Supplier();
        }

        private void btnlogout_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow = new MainWindow();

            Application.Current.MainWindow.Show();
            Window.GetWindow(this).Close();
        }

        private void btn_report_Click(object sender, RoutedEventArgs e)
        {
            ShowContent.Content = new Report2();
        }

        //private void btn_bill_Click(object sender, RoutedEventArgs e)
        //{
        //    ShowContent.Content = new Bill();

        //}

        private void btn_recovery_Click(object sender, RoutedEventArgs e)
        {
            ShowContent.Content = new ReturnSupplier();
        }

        private void Founding_Click(object sender, RoutedEventArgs e)
        {
            ShowContent.Content = new FoundingSupplier();
        }
    }
}
