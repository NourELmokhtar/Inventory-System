using ElC.Classes;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ElC
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : UserControl
    {
        InventoryEntity context = new InventoryEntity();
        public string LoginName { get; set; }
        public Login()
        {
            InitializeComponent();
        }

        public Login(string Name)
        {
            InitializeComponent();
            this.LoginName = Name;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;

        }

        private void btnlog_Click(object sender, RoutedEventArgs e)
        {
            if (LoginName == "btnAdmin")
            {
                Admin Admin = new Admin();
                bool FlagAdmin = false;
                List<Admin> admins = context.Admin.ToList();
                foreach (Admin admin in admins)
                {
                    if (admin.User == user.Text && admin.Password == pass.Password.ToString())
                    {

                        FlagAdmin = true;
                        Admin = admin;
                    }
                   
                }
                if (FlagAdmin)
                {
                    MainWindow win = (MainWindow)Application.Current.MainWindow;
                    win.Show();
                    win.ElcDeviecs.Content = new Homme();


                    SupplierBill.admin = Admin;
                }
                else
                {
                    MessageBox.Show("Please Enter valid Username and Password ;) ");
                }

            }
            else if (LoginName == "btnCashier")
            {
                bool FlagCashier = false;
                Cashier Cashier = new Cashier();
                List<Cashier> cashiers = context.Cashier.ToList();
                foreach (Cashier cashier in cashiers)
                {
                    if (cashier.User == user.Text && cashier.Password == pass.Password.ToString())
                    {
                        FlagCashier = true;
                        Cashier = cashier;
                    }
                 
                }
                if (FlagCashier)
                {
                    MainWindow win = (MainWindow)Application.Current.MainWindow;
                    win.Show();
                    win.ElcDeviecs.Content = new ElC.LoginAsKashier();
                    CustomerBill.cashier = Cashier;
                }
                else
                {
                    MessageBox.Show("Please Enter valid Username and Password ;) ");

                }

            }
        }


    }
}
