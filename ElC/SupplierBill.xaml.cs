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
    /// Interaction logic for SupplierBill.xaml
    /// </summary>
    public partial class SupplierBill : UserControl
    {
        InventoryEntity context = new InventoryEntity();
        List<Product> ProductThatWillBuy = new List<Product>();


        public static Admin admin { get; set; }

        public SupplierBill()
        {
            InitializeComponent();
        }

        public SupplierBill(List<Product> ProductSell)
        {
            InitializeComponent();
            ProductThatWillBuy = ProductSell;
            CartPayment.ItemsSource = ProductSell;
            AdminName.Text = admin.Name;
            double sum = 0;
            foreach (Product product in ProductSell)
            {
                sum += product.BuyPrice * product.Quantaty;
            }
            TotalPrice.Text = sum.ToString();
            SupplierNameBill.ItemsSource = context.Supplier.Select(s => s.Name).ToList();


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
            if (SupplierPhone.Text != "" && SupplierNameBill.SelectedValue.ToString() != "")
            {

                if (WayOfPay.IsChecked == true || Payed.Text != "")
                {

                    int SupplierID = context.Supplier.Where(S => S.Phone == SupplierPhone.Text).Select(S => S.Id).FirstOrDefault();

                    OrderSupplier order = new OrderSupplier();
                    order.SupplierID = SupplierID;
                    order.Date = DateTime.Now;
                    context.OrderSupplier.Add(order);
                    context.SaveChanges();

                    if (WayOfPay.IsChecked == true)
                    {
                        order.Payed = int.Parse(TotalPrice.Text);
                        order.Reminder = 0;
                        order.Total = int.Parse(TotalPrice.Text);

                    }
                    else
                    {
                        order.Payed = int.Parse(Payed.Text);
                        order.Reminder = int.Parse(TotalPrice.Text) - int.Parse(Payed.Text);
                        order.Total = int.Parse(TotalPrice.Text);
                    }

                    foreach (Product item in ProductThatWillBuy)
                    {
                        Product p = context.Product.Where(p => p.Name == item.Name && p.CategoryID == item.CategoryID).FirstOrDefault();
                        if (p != null)
                        {
                            context.OrderItemSupplier.Add(new OrderItemSupplier
                            {

                                OrderSupplierID = order.Id,
                                ProductID = p.Id,
                                Count = item.Quantaty,

                            });


                            p.Quantaty += item.Quantaty;
                            p.SellPrice = p.BuyPrice * 1.5;
                            context.SaveChanges();
                        }
                        else
                        {
                            Product NewProduct = new Product
                            {
                                Name = item.Name,
                                Description = item.Description,
                                Quantaty = item.Quantaty,
                                BuyPrice = item.BuyPrice,
                                SellPrice = item.BuyPrice * 1.5,
                                CategoryID = item.CategoryID,
                                Type = item.Type,
                                SupplierID = SupplierID,
                                Exist = true,

                            };
                            context.Product.Add(NewProduct);
                            context.SaveChanges();
                            context.OrderItemSupplier.Add(new OrderItemSupplier
                            {

                                OrderSupplierID = order.Id,
                                ProductID = NewProduct.Id,
                                Count = item.Quantaty,

                            });
                            context.SaveChanges();

                        }
                    }
                    CartPayment.ItemsSource = null;
                    MessageBox.Show("Success");
                    int.TryParse(Payed.Text, out int payed);
                    int.TryParse(TotalPrice.Text, out int totalprice);
                    reminder.Text = (totalprice - payed).ToString();
                    TotalPrice.Text = "";
                    Payed.Text = "";
                }
                else
                {
                    MessageBox.Show("Please select way of payment");
                }
                
               
            }
            else
            {
                MessageBox.Show("Enter Supplier Phone");
            }

        }






        private void CancelOrder_Click(object sender, RoutedEventArgs e)
        {
            CartPayment.ItemsSource = null;
            TotalPrice.Text = "";
            MessageBox.Show("Cancle Successfull");
        }
        //Back to increase Products
        private void BackToProducts_Click(object sender, RoutedEventArgs e)
        {
            Homme homme = new Homme();
            homme.ShowContent.Content = new SupplierBill();
            this.Content = new Supplier(ProductThatWillBuy);
        }

        private void SupplierNameBill_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SupplierPhone.Text = context.Supplier.Where(s => s.Name == SupplierNameBill.SelectedValue.ToString()).Select(p => p.Phone).FirstOrDefault();
        }
    }
}



