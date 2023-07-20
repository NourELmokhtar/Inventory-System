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

namespace ElC
{
    /// <summary>
    /// Interaction logic for CustomerBill.xaml
    /// </summary>
    public partial class CustomerBill : UserControl
    {
        public static Cashier cashier { get; set; }
        InventoryEntity context = new InventoryEntity();
        List<Product> ProductThatWillSell = new List<Product>();
        public CustomerBill()
        {
            InitializeComponent();
        }
        public CustomerBill(List<Product> ProductSell)
        {
            InitializeComponent();
            ProductThatWillSell = ProductSell;
            CartPayment.ItemsSource = ProductSell;
            double sum = 0;
            foreach (Product product in ProductSell)
            {
                sum += product.SellPrice * product.Quantaty;
            }
            Total_Price.Text = sum.ToString();
            CashierName.Text = cashier.Name;
        }
        private void WayOfPay_Checked(object sender, RoutedEventArgs e)
        {
            if (WayOfPay.IsChecked == true)
            {
                PartPay.Visibility = Visibility.Hidden;
                Reminder.Visibility = Visibility.Hidden;
            }
        }

        private void WayOfPay_Unchecked(object sender, RoutedEventArgs e)
        {
            if (WayOfPay.IsChecked == false)
            {
                PartPay.Visibility = Visibility.Visible;
                Reminder.Visibility = Visibility.Visible;

            }
        }

        private void CreateBill_Click(object sender, RoutedEventArgs e)
        {
            if (CustomerName.Text != "" && CustomerPhone.Text != "")
            {


                customer customer = context.Customer.Where(c => c.Phone == CustomerPhone.Text).FirstOrDefault();

                if (customer == null)
                {
                    customer = new customer();
                    customer.Name = CustomerName.Text;
                    customer.Phone = CustomerPhone.Text;
                    context.Customer.Add(customer);
                    context.SaveChanges();

                }
                Order order = new Order();
                order.CashierID = 1;
                order.CustId = customer.Id;

                order.CustId = customer.Id;
                order.Date = DateTime.Now;
                if (WayOfPay.IsChecked == true)
                {
                    order.Payed = int.Parse(Total_Price.Text);
                    order.Reminder = 0;
                    order.Total = int.Parse(Total_Price.Text);

                    order.CashierID = 1;
                }
                else
                {
                    order.Payed = int.Parse(PayedMony.Text);
                    order.Reminder = int.Parse(Total_Price.Text) - int.Parse(PayedMony.Text);
                    order.Total = int.Parse(Total_Price.Text);
                    order.CashierID = 1;
                }
                context.Order.Add(order);
                context.SaveChanges();

                foreach (var item in ProductThatWillSell)
                {
                    var product = item as Product;
                    context.OrderItem.Add(new OrderItem
                    {
                        OrderID = order.Id,
                        ProductID = item.Id,
                        Count = item.Quantaty,

                    });

                    Product p = context.Product.Where(p => p.Id == item.Id).FirstOrDefault();

                    p.Quantaty -= item.Quantaty;
                    context.SaveChanges();
                }
                context.SaveChanges();
                CartPayment.ItemsSource = null;
            }
            else
            {
                MessageBox.Show("Enter valid data");
            }

        }

        private void BackToProductCustomert_Click(object sender, RoutedEventArgs e)
        {
            //Product Customer

            Homme homme = new Homme();
            homme.ShowContent.Content = new SupplierBill();
            this.Content = new Customer(ProductThatWillSell);
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            CartPayment.ItemsSource = null;
            Total_Price.Text = "";
            MessageBox.Show("Cancle Successfull");

        }
    }
}
