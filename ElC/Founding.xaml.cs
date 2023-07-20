using ElC.Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
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
    /// Interaction logic for Founding.xaml
    /// </summary>
    public partial class Founding : UserControl
    {
        InventoryEntity context = new InventoryEntity();
        public Founding()
        {
            InitializeComponent();
        }




        public void ShowData()
        {
            if (CustomerPhone.Text != "")
            {
                int CustomerID = context.Customer.Where(c => c.Phone == CustomerPhone.Text).Select(c => c.Id).FirstOrDefault();
                if (CustomerID != 0)
                {

                    var Details = context.Order.Where(x => x.Customer.Id == CustomerID).FirstOrDefault();
                    if (Details != null)
                    {

                        var products = context.OrderItem.Where(o => o.OrderID == Details.Id && Details.Reminder > 0).Select(x => new
                        {
                            ProductName = x.Product.Name,
                            ProductCategory = x.Product.Category.Name,
                            ProductType = x.Product.Type,
                            ProductQuantity = x.Product.Quantaty,
                            ProductPrice = x.Product.SellPrice,
                        }).ToList();
                        CartPaymentGrid.ItemsSource = products;
                        TotalPrice.Text = Details.Total.ToString();
                        PayedMoney.Text = Details.Payed.ToString();
                        Reminder.Text = Details.Reminder.ToString();
                    }
                        CustomerName.Text = context.Customer.Where(c => c.Id == CustomerID).Select(x => x.Name).FirstOrDefault();

                }
                else
                {
                    MessageBox.Show("Make sure of number");
                }
            }

        }
        private void CustomerPhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ShowData();
            }
        }


        private void CustomerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                MessageBox.Show("Enter Phone Number");
            }
        }

        private void Pay_Click(object sender, RoutedEventArgs e)
        {
            if (CustomerName.Text != "" && CustomerPhone.Text != "")
            {

                int CustomerID = context.Customer.Where(c => c.Phone == CustomerPhone.Text).Select(c => c.Id).FirstOrDefault();
                var Details = context.Order.Where(x => x.Customer.Id == CustomerID).FirstOrDefault();
                var products = context.OrderItem.Where(o => o.OrderID == Details.Id).Select(x => new
                {
                    ProductName = x.Product.Name,
                    ProductCategory = x.Product.Category.Name,
                    ProductType = x.Product.Type,
                    ProductQuantity = x.Product.Quantaty,
                    ProductPrice = x.Product.SellPrice,
                }).ToList();
                Details.Payed += int.Parse(PayedMoney.Text);
                Details.Reminder -= int.Parse(PayedMoney.Text);
                PayedMoney.Text = Details.Payed.ToString();
                context.SaveChanges();
                if (Details.Reminder == 0)
                {
                    MessageBox.Show("Completed");
                }
                Reminder.Text = Details.Reminder.ToString();
            }
            else
            {
                MessageBox.Show("Enter Customer Data");
            }
        }
    }
}






