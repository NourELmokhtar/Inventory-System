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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ElC
{  /// <summary>
   /// Interaction logic for Report2.xaml
   /// </summary>
    public partial class Report2 : UserControl
    {
        InventoryEntity context = new InventoryEntity();
        List<string> list = new List<string>()
        {
            "customer",
            "supplier"
        };
        List<string> listBuying = new List<string>()
        {
            "Returns",
            "Orders"
        };
        public Report2()
        {
            InitializeComponent();
            CustomerORsupplier.ItemsSource = list;
            RefundsOrders.ItemsSource = listBuying;

        }
       


        private void PrintBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CustomerORsupplier.SelectedItem == "customer" && RefundsOrders.SelectedItem == "Orders")
            {
                if (datepicker.SelectedDate.HasValue == false)
                {
                    var query = context.Order.Include(c => c.Customer).Include(c => c.Cashier)
                    .Select(x => new
                    {
                        Id = x.Id,
                        CustomerName = x.Customer.Name,
                        CashierName = x.Cashier.Name,
                        TotalPrice = x.Total,
                        Payed = x.Payed,
                        Reminder = x.Reminder,

                        Date = x.Date,
                    }).ToList();
                    ProductsGrid.ItemsSource = query;

                }
                else
                {

                    //SELECTED DATE
                    var query = context.Order.Include(c => c.Customer).Include(c => c.Cashier)
                    .Where(x => x.Date == (datepicker.SelectedDate.Value))
                        .Select(x => new
                        {
                            Id = x.Id,
                            CustomerName = x.Customer.Name,
                            CashierName = x.Cashier.Name,
                            TotalPrice = x.Total,
                            Payed = x.Payed,
                            Reminder = x.Reminder,

                            Date = x.Date,
                        }).ToList();
                    ProductsGrid.ItemsSource = query;
                    datepicker.SelectedDate = null;
                }

                ProductsGrid.Visibility = Visibility.Visible;
                ProductsGridReturned.Visibility = Visibility.Collapsed;
                ProductsGridReturnedSupplier.Visibility = Visibility.Collapsed;
                ProductsGridOrderSupplier.Visibility = Visibility.Collapsed;
            }

            //RETURNS

            else if (CustomerORsupplier.SelectedItem == "customer" && RefundsOrders.SelectedItem == "Returns")

            {
                //WITHOUT DATE
                if (datepicker.SelectedDate.HasValue == false)
                {
                    var queryCustomer = context.ReturnCustomerProduct.Include(x => x.Order).ThenInclude(x => x.Customer).Include(x => x.Product)
                  .Select(r =>
                  new
                  {
                      OrderId = r.OrderID,
                      CustomerName = r.Order.Customer.Name,
                      ProductName = r.Product.Name,
                      ProductCount = r.Count,
                      TotalPrice = r.Product.SellPrice,
                      Reminder = r.Order.Reminder,
                      Payed = r.Order.Payed,
                      Date = r.Date,

                  }).ToList();
                    ProductsGridReturned.ItemsSource = queryCustomer;

                }
                else
                {
                    //WITH DATE
                    var queryCustomer = context.ReturnCustomerProduct.Include(x => x.Order).ThenInclude(x => x.Customer).Include(x => x.Product)
                         .Where(x => x.Date.Date == datepicker.SelectedDate.Value.Date)
                        .Select(r =>
                  new
                  {
                      OrderId = r.OrderID,
                      CustomerName = r.Order.Customer.Name,
                      ProductName = r.Product.Name,
                      ProductCount = r.Count,
                      TotalPrice = r.Product.SellPrice,
                      Reminder = r.Order.Reminder,
                      Payed = r.Order.Payed,
                      Date = r.Date,

                  }).ToList();
                    ProductsGridReturned.ItemsSource = queryCustomer;

                }


                ProductsGridReturned.Visibility = Visibility.Visible;
                ProductsGrid.Visibility = Visibility.Collapsed;
                ProductsGridReturnedSupplier.Visibility = Visibility.Collapsed;
                ProductsGridOrderSupplier.Visibility = Visibility.Collapsed;


            }




            // Supplier



            else if (CustomerORsupplier.SelectedItem == "supplier" && RefundsOrders.SelectedItem == "Returns")

            {
                //WITHOUT DATE
                if (datepicker.SelectedDate.HasValue == false)
                {
                    var QuerySupplier = context.ReturnInventoryProduct.Include(x => x.OrderSupplier).ThenInclude(x => x.Supplier).Include(x => x.Product)
                  .Select(r =>
                  new
                  {
                      OrderId = r.OrderSupplierID,
                      SupplierName = r.OrderSupplier.Supplier.Name,
                      ProductName = r.Product.Name,
                      ProductCount = r.Count,
                      TotalPrice = r.Product.BuyPrice,
                      Reminder = r.OrderSupplier.Reminder,
                      Payed = r.OrderSupplier.Payed,
                      Date = r.Date,

                  }).ToList();
                    ProductsGridReturnedSupplier.ItemsSource = QuerySupplier;

                }
                else
                {
                    //WITH DATE
                    var querySupplier = context.ReturnInventoryProduct.Include(x => x.OrderSupplier).ThenInclude(x => x.Supplier).Include(x => x.Product)
                         .Where(x => x.Date.Date == datepicker.SelectedDate.Value.Date)
                        .Select(r =>
                  new
                  {
                      OrderId = r.OrderSupplierID,
                      SupplierName = r.OrderSupplier.Supplier.Name,
                      ProductName = r.Product.Name,
                      ProductCount = r.Count,
                      TotalPrice = r.Product.BuyPrice,
                      Reminder = r.OrderSupplier.Reminder,
                      Payed = r.OrderSupplier.Payed,
                      Date = r.Date,

                  }).ToList();
                    ProductsGridReturnedSupplier.ItemsSource = querySupplier;

                }

                ProductsGridReturnedSupplier.Visibility = Visibility.Visible;
                ProductsGridOrderSupplier.Visibility = Visibility.Collapsed;
                ProductsGrid.Visibility = Visibility.Collapsed;
                ProductsGridReturned.Visibility = Visibility.Collapsed;


            }
            //Order

            else if (CustomerORsupplier.SelectedItem == "supplier" && RefundsOrders.SelectedItem == "Orders")
            {
                //WITHOUT DATE
                if (datepicker.SelectedDate.HasValue == false)

                {
                    var query = context.OrderSupplier.Include(c => c.Supplier).ThenInclude(c => c.Products)
                    .Select(x => new
                    {
                        OrderId = x.Id,
                        SupplierName = x.Supplier.Name,
                        ProductCount = x.Supplier.Products.Count(),
                        TotalPrice = x.Total,
                        Payed = x.Payed,
                        Reminder = x.Reminder,

                        Date = x.Date,
                    }).ToList();
                    ProductsGridOrderSupplier.ItemsSource = query;

                }
                else
                {

                    //SELECTED DATE
                    var query = context.OrderSupplier.Include(c => c.Supplier).ThenInclude(c => c.Products)
                    .Where(x => x.Date.Date == datepicker.SelectedDate.Value.Date)
                        .Select(x => new
                        {
                            Id = x.Id,
                            SupplierName = x.Supplier.Name,
                            ProductCount = x.Supplier.Products.Count(),
                            TotalPrice = x.Total,
                            Reminder = x.Reminder,
                            Payed = x.Payed,
                            Date = x.Date,
                        }).ToList();
                    ProductsGridOrderSupplier.ItemsSource = query;
                    datepicker.SelectedDate = null;
                }
                ProductsGridOrderSupplier.Visibility = Visibility.Visible;
                ProductsGridReturnedSupplier.Visibility = Visibility.Collapsed;
                ProductsGrid.Visibility = Visibility.Collapsed;
                ProductsGridReturned.Visibility = Visibility.Collapsed;
            }
            else
            {
                MessageBox.Show("You should choose type ");
            }



            //DateTime.Now.ToString("dd/MM/yyyy").Replace('-','/');



        }

       
    }
}