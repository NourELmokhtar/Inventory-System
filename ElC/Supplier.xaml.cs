using ElC.Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.RightsManagement;
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
    /// Interaction logic for Supplier.xaml
    /// </summary>

    /// <summary>
    /// Interaction logic for Supplier.xaml
    /// </summary>
    public partial class Supplier : UserControl
    {

        // List<Product> SupplierList = new List<Product>();
        InventoryEntity context = new InventoryEntity();
        HashSet<string> Types = new HashSet<string>();
        List<Product> BuyedProduct = new List<Product>();

        public Supplier()
        {
            InitializeComponent();
            ShowCategoriesName();
            ShowItem.ItemsSource = null;
            ShowItem.ItemsSource = context.Product.Include(p => p.Category).ToList();


        }
        public Supplier(List<Product> products)
        {
            InitializeComponent();
            ShowCategoriesName();
            BuyedProduct = products;
            // CartGrid.ItemsSourc = products;
            CartGrid.ItemsSource = products;

            ShowItem.ItemsSource = null;
            ShowItem.ItemsSource = context.Product.Include(p => p.Category).ToList();


        }
        //Supplier Name


        public void ShowCategoriesName()
        {
            List<string> Categories = context.Category.Select(s => s.Name).ToList();
            CategoriesName.ItemsSource = Categories;

            //  ProductType.Visibility = Visibility.Hidden;
        }



        private void CheckedBox_Checked(object sender, RoutedEventArgs e)
        {
            if (CheckedBox.IsChecked == true)
            {
                AddNewCategory.Visibility = Visibility.Visible;
            }


        }
        //Add NewCategory
        private void NewCategory_Click(object sender, RoutedEventArgs e)
        {

            Category NewCategoryAdd = new Category();
            NewCategoryAdd.Name = CategoryName.Text;
            context.Category.Add(NewCategoryAdd);
            context.SaveChanges();

            CategoriesName.ItemsSource = null;
            ShowCategoriesName();
            CheckedBox.IsChecked = false;
            AddNewCategory.Visibility = Visibility.Hidden;
            CategoriesName.Text = CategoryName.Text;

        }
        //Types
        private void CategoriesName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            List<Product> products = context.Product.Where(p => p.Category.Name == CategoriesName.SelectedValue).ToList();
            string CatName = "";
            ShowItem.ItemsSource = null;
            ShowItem.ItemsSource = products;

            if (CategoriesName.SelectedIndex >= 0)
            {
                SelectedType.Visibility = Visibility.Visible;
                CatName = CategoriesName.SelectedValue.ToString();

            }

            TypeName.ItemsSource = null;
            var Type = context.Product.Where(p => p.Category.Name == CategoriesName.SelectedValue).Select(p => p.Type).ToList();
            Types.Clear();
            foreach (var item in Type)
            {
                Types.Add(item);
            }
            if (Type.Count > 0)
                TypeName.ItemsSource = Types;
            else
                TypeName.ItemsSource = null;
        }
        //Type 
        private void TypeName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TypeName.SelectedItem != null)
            {

                string CatName = CategoriesName.SelectedValue.ToString();
                string typeName = TypeName.SelectedValue.ToString();
                var products = context.Product
                    .Where(E => E.Category.Name == CatName && typeName == E.Type).Include(p=>p.Category).ToList();

                ShowItem.ItemsSource = null;
                ShowItem.ItemsSource = products;
                 ProductType.Text = TypeName.SelectedValue.ToString();
            }
        }
        //Selected For Grid 
        private void ShowItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Product SelectedProduct = ShowItem.SelectedItem as Product;
            if (SelectedProduct != null)
            {
                string Name = context.Product.Where(p => p.Supplier.Id == SelectedProduct.SupplierID).Select(p => p.Supplier.Name).FirstOrDefault();

                ProductType.Text = SelectedProduct.Type.ToString();
                ProductName.Text = SelectedProduct.Name.ToString();
                ProductPrice.Text = SelectedProduct.BuyPrice.ToString();
                ProductQuantity.Text = SelectedProduct.Quantaty.ToString();
                ProductDescription.Text = SelectedProduct.Description.ToString();
                CategoriesName.Text = SelectedProduct.Category.Name.ToString();
            }

        }
        //AddProductToCart
        private void AddProductToCart_Click(object sender, RoutedEventArgs e)
        {

            if (ProductPrice.Text != "" && ProductQuantity.Text != "" && ProductDescription.Text != "" && ProductName.Text != "" && ProductType.Text != "" && CategoriesName.Text != "")
            {
                int.TryParse(ProductQuantity.Text, out int NewProductQuantity);
                int.TryParse(ProductPrice.Text, out int NewProductPrice);
                if (NewProductPrice > 0 && NewProductQuantity > 0)
                {

                    #region AddToCart
                    string NewProductType = ProductType.Text;
                    string NewProductName = ProductName.Text;
                    string NewProductDescription = ProductDescription.Text;

                    Product NewProdct = new Product();
                    int CatID = context.Category.Where(c => c.Name == CategoriesName.Text).Select(i => i.Id).FirstOrDefault();
                    NewProdct.CategoryID = CatID;
                    NewProdct.Name = NewProductName;
                    NewProdct.Type = NewProductType;
                    NewProdct.Description = NewProductDescription;
                    NewProdct.Quantaty = NewProductQuantity;
                    NewProdct.BuyPrice = NewProductPrice;
                    NewProdct.SellPrice = NewProductPrice * 1.5;

                    bool flag = false;
                    foreach (Product product in BuyedProduct)
                    {
                        //MessageBox.Show(product.Id.ToString());
                        if (product.Name == NewProdct.Name)
                        {
                            product.Quantaty += int.Parse(ProductQuantity.Text);
                            flag = true;

                        }

                    }
                    if (flag == false)
                    {
                        BuyedProduct.Add(NewProdct);
                    }


                    CartGrid.ItemsSource = null;
                    CartGrid.ItemsSource = BuyedProduct;
                    MessageBox.Show("Item had been Added");
                    ProductName.Text = "";
                    ProductPrice.Text = "";
                    ProductQuantity.Text = "";
                    ProductType.Text = "";
                    ProductDescription.Text = "";
                    ShowItem.SelectedItem = null;
                    #endregion
                }
                else
                {
                    MessageBox.Show("InValid Data");
                }
            }
            else
            {
                MessageBox.Show("InValid Data");
            }


        }

        private void DeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            Product product = (Product)CartGrid.SelectedItem;

            BuyedProduct.Remove(product);
            CartGrid.ItemsSource = null;
            CartGrid.ItemsSource = BuyedProduct;
        }

        private void UpdateIcon_Click(object sender, RoutedEventArgs e)
        {
            if (CartGrid.SelectedItem != null)
            {
                Product product = (Product)CartGrid.SelectedItem;
                ProductName.Text = product.Name;
                ProductType.Text = product.Type;
                ProductDescription.Text = product.Description;
                ProductQuantity.Text = product.Quantaty.ToString();
                ProductPrice.Text = product.SellPrice.ToString();

            }
            else
            {
                MessageBox.Show("Select Product To Update");
            }

        }
        //Update Product
        private void UpdateProduct_Click(object sender, RoutedEventArgs e)
        {
            Product product = (Product)CartGrid.SelectedItem;
            //MessageBox.Show(product.Name);
            if (product != null)
            {

            product.Quantaty = Convert.ToInt32(ProductQuantity.Text);
            product.BuyPrice = Convert.ToInt32(ProductPrice.Text);
            product.SellPrice = product.BuyPrice * 1.5;
            product.Description = ProductDescription.Text;
            product.Name = ProductName.Text;
            product.Type = ProductType.Text;

            CartGrid.ItemsSource = null;
            CartGrid.ItemsSource = BuyedProduct;
            ProductName.Text = "";
            ProductPrice.Text = "";
            ProductQuantity.Text = "";
            ProductType.Text = "";
            ProductDescription.Text = "";
            }
            else
            {
                MessageBox.Show("PLease select product");
            }
        }

        private void Payment_Click(object sender, RoutedEventArgs e)
        {
            if (CartGrid.Items.Count > 0)
            {

            Homme homme = new Homme();
            homme.ShowContent.Content = new SupplierBill();
            this.Content = new SupplierBill(BuyedProduct);
            }
            else
            {
                MessageBox.Show("Please Enter Product");
            }
            // int supplierId = context.Product.FirstOrDefault(P => P.SupplierID.);
        }

       
    }

}

