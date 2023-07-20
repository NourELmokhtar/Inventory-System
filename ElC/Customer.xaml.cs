using System.Windows.Controls;

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
using ElC.Classes;

namespace ElC
{
    /// <summary>
    /// Interaction logic for Customer.xaml
    /// </summary>
    public partial class Customer : UserControl
    {
        InventoryEntity context = new InventoryEntity();
        List<Product> ProductsBuy = new List<Product>();

        public Customer()
        {
            InitializeComponent();

            cat_name();

        }
        public Customer(List<Product> products)
        {
            InitializeComponent();

            cat_name();
            ProductsBuy = products;
            CartGrid.ItemsSource = products;



        }

        public void cat_name()
        {
            IEnumerable<string> names = context.Category.Select(E => E.Name).ToList();
            CategoriesName.ItemsSource = names;
        }

        private void CategoriesName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            HashSet<string> Type = new HashSet<string>();

            IEnumerable<string> Types = context.Product.Where(p => p.Category.Name == CategoriesName.SelectedValue)
                  .Select(p => p.Type).ToList();
            foreach (string item in Types)
            {
                Type.Add(item);
            }
            TypeName.ItemsSource = Type;
            List<Product> products = context.Product.Where(p => p.Category.Name == CategoriesName.SelectedValue).ToList();
            ProductsGrid.ItemsSource = null;
            ProductsGrid.ItemsSource = products;




        }

        List<Product> product;
        private void TypeName_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (TypeName.SelectedItem != null)
            {
                string Type_Name = TypeName.SelectedValue.ToString();
                 product = context.Product.Where(p => p.Category.Name == CategoriesName.SelectedItem.ToString() && p.Type == TypeName.SelectedItem.ToString()&&p.Quantaty>0).ToList();

                ProductsGrid.ItemsSource = null;

                ProductsGrid.ItemsSource = product;
            }
        }




        private void ProductsGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (ProductsGrid.SelectedItem != null)
            {
                Product product = (Product)ProductsGrid.SelectedItem;

                ProductName.Text = product.Name;
                ProductQuantity.Text = product.Quantaty.ToString();

            }
        }


        private void DeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            //Delete Product
            Product product = (Product)CartGrid.SelectedItem;

            ProductsBuy.Remove(product);
            CartGrid.ItemsSource = null;
            CartGrid.ItemsSource = ProductsBuy;

        }



        private void ADD_Click(object sender, RoutedEventArgs e)
        {
            Product BuyedProduct = (Product)ProductsGrid.SelectedItem;
            if (BuyedProduct != null)
            {

                int.TryParse(ProductQuantity.Text, out int quantity);
                if (quantity > 0)
                {

                   

                    if (BuyedProduct.Quantaty < int.Parse(ProductQuantity.Text))
                    {
                        MessageBox.Show("Sorry!! We Don't Have This Quantity");
                    }
                    else
                    {
                        Product productAddedd = new Product
                        {
                            Id = BuyedProduct.Id,
                            Name = BuyedProduct.Name,
                            CategoryID = BuyedProduct.CategoryID,
                            Type = BuyedProduct.Type,
                            SupplierID = BuyedProduct.SupplierID,
                            Description = BuyedProduct.Description,
                            Quantaty = int.Parse(ProductQuantity.Text),
                            SellPrice = BuyedProduct.SellPrice,
                        };
                        bool flag = false;
                        foreach (Product product in ProductsBuy)
                        {
                            if (product.Id == BuyedProduct.Id)
                            {
                                product.Quantaty += int.Parse(ProductQuantity.Text);
                                flag = true;

                            }

                        }
                        if (flag == false)
                        {
                            ProductsBuy.Add(productAddedd);
                        }
                        ProductsGrid.SelectedItem = null;

                        CartGrid.ItemsSource = null;

                        CartGrid.ItemsSource = ProductsBuy;
                        ProductName.Text = "";
                        ProductQuantity.Text = "";


                    }

                }
            }
            else
            {
                MessageBox.Show("Select The Product");
            }
            
        }

        private void CreateBill_Click(object sender, RoutedEventArgs e)
        {
            Homme homme = new Homme();
            homme.ShowContent.Content = new CustomerBill();
            if (CartGrid.Items.Count > 0)
            {
                this.Content = new CustomerBill(ProductsBuy);
            }
            else
            {
                MessageBox.Show("Select items");
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (CartGrid.SelectedItem != null)
            {
                Product product = (Product)CartGrid.SelectedItem;
                product.Quantaty = Convert.ToInt32(ProductQuantity.Text);

                CartGrid.ItemsSource = null;
                CartGrid.ItemsSource = ProductsBuy;
                ProductQuantity.Text = "";
            }
            else
            {
                MessageBox.Show("Select Product To Update");
            }
        }

        private void UpdateGrid_Click(object sender, RoutedEventArgs e)
        {
            Product product = (Product)CartGrid.SelectedItem;
            ProductQuantity.Text = product.Quantaty.ToString();
        }


    }
}
