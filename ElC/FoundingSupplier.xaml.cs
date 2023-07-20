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
    /// Interaction logic for FoundingSupplier.xaml
    /// </summary>
    public partial class FoundingSupplier : UserControl
    {
        InventoryEntity context = new InventoryEntity();
        public FoundingSupplier()
        {
            InitializeComponent();
        }
        public void ShowData()
        {
            if (SupplierPhone.Text != "")
            {
                int SupplierID = context.Supplier.Where(c => c.Phone == SupplierPhone.Text).Select(c => c.Id).FirstOrDefault();


                if (SupplierID != 0)
                {

                    var Details = context.OrderSupplier.Where(x => x.Supplier.Id == SupplierID).FirstOrDefault();
                    if (Details != null)
                    {

                        var products = context.OrderItemSupplier.Where(o => o.OrderSupplierID == Details.Id && Details.Reminder > 0).Select(x => new
                        {
                            ProductName = x.Product.Name,
                            ProductCategory = x.Product.Category.Name,
                            ProductType = x.Product.Type,
                            ProductQuantity = x.Product.Quantaty,
                            ProductPrice = x.Product.BuyPrice,
                        }).ToList();
                        CartPaymentGrid.ItemsSource = products;
                        TotalPrice.Text = Details.Total.ToString();
                        PayedMoney.Text = Details.Payed.ToString();
                        Reminder.Text = Details.Reminder.ToString();
                    }
                    SupplierName.Text = context.Supplier.Where(c => c.Id == SupplierID).Select(x => x.Name).FirstOrDefault();

                }
                else
                {
                    MessageBox.Show("Make sure of number");
                }
            }

        }
        private void SupplierPhone_KeyDown(object sender, KeyEventArgs e)
        {
            // SUPPLIER PHONE
            if (e.Key == Key.Enter)
            {
                ShowData();
            }
        }

        private void SupplierName_KeyDown(object sender, KeyEventArgs e)
        {
            /// SUPPLIER nAME 
            /// 
            if (e.Key == Key.Enter)
            {
                MessageBox.Show("Enter Phone Number");
            }
        }

        private void Pay_Click(object sender, RoutedEventArgs e)
        {
            if (SupplierPhone.Text != "" && SupplierName.Text != "")
            {

                int SupplierID = context.Supplier.Where(c => c.Phone == SupplierPhone.Text).Select(c => c.Id).FirstOrDefault();
                var Details = context.OrderSupplier.Where(x => x.Supplier.Id == SupplierID).FirstOrDefault();
                var products = context.OrderItemSupplier.Where(o => o.OrderSupplierID == Details.Id).Select(x => new
                {
                    ProductName = x.Product.Name,
                    ProductCategory = x.Product.Category.Name,
                    ProductType = x.Product.Type,
                    ProductQuantity = x.Product.Quantaty,
                    ProductPrice = x.Product.BuyPrice,
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
                MessageBox.Show("Enter supplier Data");
            }
        }
    }
}


