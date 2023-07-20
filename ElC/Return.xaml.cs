using ElC.Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ElC
{
    /// <summary>
    /// Interaction logic for Return.xaml
    /// </summary>
    public partial class Return : System.Windows.Controls.UserControl
    {
        InventoryEntity context = new InventoryEntity();
        public Return()
        {
            InitializeComponent();
            OrderID.ItemsSource = context.Order
                .Select(o => o.Id).ToList();

        }

        public void ShowProduct()
        {
            var OT = context.OrderItem.Where(ot => ot.OrderID == int.Parse(OrderID.SelectedValue.ToString()) && ot.Count != 0)
                .Include(ot => ot.Product)
                .Include(ot => ot.Order)
                .ThenInclude(c => c.Customer)
                .Select(e => new { ProductName = e.Product.Name, CustomerName = e.Order.Customer.Name, BuyDate = e.Order.Date, ProductQuantity = e.Count })
                .ToList();

            Product.ItemsSource = null;
            Product.ItemsSource = OT;
        }

        private void OrderID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            ShowProduct();


        }


        private void Product_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Product.SelectedItem != null)
            {

                string ProductName = (Product.SelectedCells[0].Column.GetCellContent(Product.SelectedItem as object) as TextBlock).Text;

                string ProductToReturn = (Product.SelectedCells[3].Column.GetCellContent(Product.SelectedItem as object) as TextBlock).Text;


                ProductNameBill.Text = ProductName;
                QuantityBill.Text = ProductToReturn;
            }
            
        }
        private void ADD_Click(object sender, RoutedEventArgs e)
        {

            if (Product.SelectedItem != null && QuantityBill.Text != "")
            {
                int.TryParse(QuantityBill.Text, out int ProductQuantity);
                if (ProductQuantity > 0)
                {

                    int que = int.Parse(QuantityBill.Text);

                    if (que <= int.Parse((Product.SelectedCells[3].Column.GetCellContent(Product.SelectedItem as object) as TextBlock).Text))
                    {

                        var list = new[]{
                         new {
                                 ProductName = ProductNameBill.Text, ProductQuantity = que,
                                 CustomerName = (Product.SelectedCells[1].Column.GetCellContent(Product.SelectedItem as object) as TextBlock).Text,
                                 BuyDate = (Product.SelectedCells[2].Column.GetCellContent(Product.SelectedItem as object) as TextBlock).Text,
                            }
                    }.ToList();
                        bool flag = false;
                        for (int i = 0; i < ReturnedProduct.Items.Count; i++)
                        {
                            if ((ReturnedProduct.Columns[0].GetCellContent(ReturnedProduct.Items[i]) as TextBlock).Text == ProductNameBill.Text)
                            {
                                int count = int.Parse((ReturnedProduct.Columns[3].GetCellContent(ReturnedProduct.Items[i]) as TextBlock).Text);
                                count += int.Parse(QuantityBill.Text);
                                (ReturnedProduct.Columns[3].GetCellContent(ReturnedProduct.Items[i]) as TextBlock).Text = count.ToString();

                                flag = true;
                            }
                        }

                        int NewQunt = int.Parse((Product.SelectedCells[3].Column.GetCellContent(Product.SelectedItem as object) as TextBlock).Text) - que;
                        (Product.SelectedCells[3].Column.GetCellContent(Product.SelectedItem as object) as TextBlock).Text = NewQunt.ToString();

                        if (!flag)
                            ReturnedProduct.Items.Add(list);
                    }

                    else
                    {
                        System.Windows.MessageBox.Show("Your quantity more than the real qantity");

                    }


                }
                else
                {
                System.Windows.MessageBox.Show("You Should Enter  number");
                }
            }
            else
            {
                    System.Windows.MessageBox.Show("You should select product");
            }

        }



        private void ReturnProduct_Click(object sender, RoutedEventArgs e)
        {
            if (ReturnedProduct.Items.Count > 0)
            {

                bool flag = false;
                List<ReturnCustomerProduct> returnCustomerProducts = context.ReturnCustomerProduct.Include(p => p.Product).Include(o => o.Order).ToList();
                List<OrderItem> orderItem = context.OrderItem.Where(o => o.OrderID == int.Parse(OrderID.Text)).ToList();
                double Sum = 0;
                int Quantity = 0;
                for (int i = 0; i < ReturnedProduct.Items.Count; i++)
                {
                    // Check if the product is exist with same order ID if it exist we will count that ++ 
                    Quantity = int.Parse((ReturnedProduct.Columns[3].GetCellContent(ReturnedProduct.Items[i]) as TextBlock).Text);
                    Product product = context.Product.Where(p => p.Name == (ReturnedProduct.Columns[0].GetCellContent(ReturnedProduct.Items[i]) as TextBlock).Text).FirstOrDefault();
                    product.Quantaty += Quantity;
                    Sum = Quantity * product.SellPrice;
                    foreach (ReturnCustomerProduct item in returnCustomerProducts)
                    {
                        if (item.ProductID == product.Id && item.OrderID == int.Parse(OrderID.Text))
                        {
                            item.Count += int.Parse((ReturnedProduct.Columns[3].GetCellContent(ReturnedProduct.Items[i]) as TextBlock).Text);
                            flag = true;
                            context.SaveChanges();

                        }

                    }
                    // if it not exist we will add it 
                    if (!flag)
                    {
                        ReturnCustomerProduct returnCustomerProduct = new ReturnCustomerProduct()
                        {
                            OrderID = int.Parse(OrderID.Text),
                            Count = int.Parse((ReturnedProduct.Columns[3].GetCellContent(ReturnedProduct.Items[i]) as TextBlock).Text),
                            Date = DateTime.Now,
                            Product = product,

                        };
                        context.ReturnCustomerProduct.Add(returnCustomerProduct);
                    }
                    context.SaveChanges();
                    foreach (OrderItem item in orderItem)
                    {
                        if (item.ProductID == product.Id)
                        {
                            item.Count -= Quantity;
                        }
                    }

                    context.SaveChanges();
                }
                Order EditOrder = context.Order.FirstOrDefault(o => o.Id == int.Parse(OrderID.Text));
                EditOrder.Total -= Sum;
                if (EditOrder.Total < EditOrder.Payed)
                {
                    EditOrder.Payed = EditOrder.Total;

                }
                EditOrder.Reminder = EditOrder.Total - EditOrder.Payed;
                context.SaveChanges();

                ReturnedProduct.Items.Clear();
            }
            else
            {
                System.Windows.MessageBox.Show("You should select product to return");
            }

            ShowProduct();
        }


    }
}

