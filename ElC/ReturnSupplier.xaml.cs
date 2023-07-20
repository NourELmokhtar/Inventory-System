using ElC.Classes;
using Microsoft.EntityFrameworkCore;
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
using System.Windows.Media.Converters;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

/// <summary>
/// Interaction logic for ReturnSupplier.xaml
/// </summary>
namespace ElC
{
    /// <summary>
    /// Interaction logic for Return.xaml
    /// </summary>
    public partial class ReturnSupplier : System.Windows.Controls.UserControl
    {
        InventoryEntity context = new InventoryEntity();

        public ReturnSupplier()
        {
            InitializeComponent();
            orderfun();
        }

        public void orderfun()
        {
            OrderID.ItemsSource = context.OrderSupplier.Select(s => s.Id).ToList();

        }

        public void ShowProduct()
        {
            Product.ItemsSource = null;

            var order_Det = context.OrderItemSupplier.Where(e => e.OrderSupplierID == int.Parse(OrderID.SelectedItem.ToString()) && e.Count != 0)
                .Include(e => e.OrderSupplier)
                .Include(e => e.OrderSupplier.Supplier)
                .ThenInclude(e => e.Products)
                .Select(e => new { productname = e.Product.Name, suppliername = e.OrderSupplier.Supplier.Name, Date = e.OrderSupplier.Date, ProductQuantity = e.Count }).ToList();

            Product.ItemsSource = order_Det;
        }


        private void OrderID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            ShowProduct();

        }




        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (Product.SelectedItem != null)
            {

                int que = int.Parse(producttoreturn.Text);

                if (que <= int.Parse((Product.SelectedCells[2].Column.GetCellContent(Product.SelectedItem as object) as TextBlock).Text))
                {

                    var list = new[]{
                         new {
                                 productname =productnametextbox.Text, ProductQuantity = que,
                                 suppliername=(Product.SelectedCells[1].Column.GetCellContent(Product.SelectedItem as object) as TextBlock).Text,
                                 Date =(Product.SelectedCells[3].Column.GetCellContent(Product.SelectedItem as object) as TextBlock).Text,
                            }
                    }.ToList();
                    bool flag = false;
                    for (int i = 0; i < ReturnedProduct.Items.Count; i++)
                    {
                        if ((ReturnedProduct.Columns[0].GetCellContent(ReturnedProduct.Items[i]) as TextBlock).Text == productnametextbox.Text)
                        {
                            int count = int.Parse((ReturnedProduct.Columns[2].GetCellContent(ReturnedProduct.Items[i]) as TextBlock).Text);
                            count += int.Parse(producttoreturn.Text);
                            (ReturnedProduct.Columns[2].GetCellContent(ReturnedProduct.Items[i]) as TextBlock).Text = count.ToString();

                            flag = true;
                        }
                    }

                    int NewQunt = int.Parse((Product.SelectedCells[2].Column.GetCellContent(Product.SelectedItem as object) as TextBlock).Text) - que;
                    (Product.SelectedCells[2].Column.GetCellContent(Product.SelectedItem as object) as TextBlock).Text = NewQunt.ToString();

                    if (!flag)
                        ReturnedProduct.Items.Add(list);
                }
                else
                {
                    MessageBox.Show("Your quantity more than the real qantity");
                }
            }
            else
            {
                MessageBox.Show("You should select the product");
            }
        }


        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            if (Product.SelectedItem != null)
            {

                bool flag = false;
                List<ReturnInventoryProduct> ReturnInventoryProducts = context.ReturnInventoryProduct.Include(p => p.Product).Include(o => o.OrderSupplier).ToList();
                List<OrderItemSupplier> OrderItemSupplier = context.OrderItemSupplier.Where(o => o.OrderSupplierID == int.Parse(OrderID.Text)).ToList();

                int Quantity = 0;
                double Sum = 0;
                for (int i = 0; i < ReturnedProduct.Items.Count; i++)
                {
                    // Check if the product is exist with same order ID if it exist we will count that ++ 
                    Quantity = int.Parse((ReturnedProduct.Columns[2].GetCellContent(ReturnedProduct.Items[i]) as TextBlock).Text);
                    Product product = context.Product.Where(p => p.Name == (ReturnedProduct.Columns[0].GetCellContent(ReturnedProduct.Items[i]) as TextBlock).Text).FirstOrDefault();
                    product.Quantaty -= Quantity;
                    Sum = Quantity * product.BuyPrice;

                    foreach (ReturnInventoryProduct item in ReturnInventoryProducts)
                    {
                        if (item.ProductID == product.Id && item.OrderSupplierID == int.Parse(OrderID.Text))
                        {
                            item.Count += int.Parse((ReturnedProduct.Columns[2].GetCellContent(ReturnedProduct.Items[i]) as TextBlock).Text);
                            flag = true;
                            context.SaveChanges();

                        }

                    }
                    // if it not exist we will add it 
                    if (!flag)
                    {
                        ReturnInventoryProduct ReturnInventoryProduct = new ReturnInventoryProduct()
                        {
                            OrderSupplierID = int.Parse(OrderID.Text),
                            Count = int.Parse((ReturnedProduct.Columns[2].GetCellContent(ReturnedProduct.Items[i]) as TextBlock).Text),
                            Date = DateTime.Now,
                            Product = product,

                        };
                        context.ReturnInventoryProduct.Add(ReturnInventoryProduct);
                    }
                    context.SaveChanges();
                    foreach (OrderItemSupplier item in OrderItemSupplier)
                    {
                        if (item.ProductID == product.Id)
                        {
                            item.Count -= Quantity;
                        }
                    }

                    context.SaveChanges();
                }

                OrderSupplier EditOrderSupplier = context.OrderSupplier.FirstOrDefault(o => o.Id == int.Parse(OrderID.Text));
                EditOrderSupplier.Total -= Sum;
                if (EditOrderSupplier.Total < EditOrderSupplier.Payed)
                {
                    EditOrderSupplier.Payed = EditOrderSupplier.Total;

                }
                EditOrderSupplier.Reminder = EditOrderSupplier.Total - EditOrderSupplier.Payed;
                context.SaveChanges();

                System.Windows.MessageBox.Show(" Sucessfully Return :) ");
                ReturnedProduct.Items.Clear();
            }
            else
            {
                MessageBox.Show("You should Add product to return");
            }
            ShowProduct();
        }




        private void Product_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {

            if (Product.SelectedItem != null)
            {

                string ProductName = (Product.SelectedCells[0].Column.GetCellContent(Product.SelectedItem as object) as TextBlock).Text;

                string ProductToReturn = (Product.SelectedCells[2].Column.GetCellContent(Product.SelectedItem as object) as TextBlock).Text;


                productnametextbox.Text = ProductName;
                producttoreturn.Text = ProductToReturn;
            }
        }

    }
}

