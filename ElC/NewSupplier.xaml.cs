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
    /// Interaction logic for NewSupplier.xaml
    /// </summary>
    public partial class NewSupplier : UserControl
    {
        InventoryEntity Context = new InventoryEntity();
        public NewSupplier()
        {
            InitializeComponent();
            ShowSupplier();
        }
        public void ShowSupplier()
        {
            //supplier p = Context.Supplier.Select(x => new {Name=x.Name , Phone=x.Phone});
            GridText.ItemsSource = Context.Supplier.ToList();

        }


     
        private void GridText_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            supplier supplier = GridText.SelectedItem as supplier;
            if (supplier != null)
            {
                nametextbox.Text = supplier.Name;
                phonetextbox.Text = supplier.Phone;

            }

        }

      

        private void ADD_Click(object sender, RoutedEventArgs e)
        {
            if (nametextbox.Text != "" && phonetextbox.Text != "")
            {

                supplier Supplier = new supplier
                {
                    Name = nametextbox.Text,
                    Phone = phonetextbox.Text,
                };
                List<supplier> SubList = Context.Supplier.ToList();
                bool flag = false;
                if (SubList == null)
                {
                    Context.Supplier.Add(Supplier);

                }
                else
                {
                    foreach (supplier supplier in SubList)
                    {
                        if (supplier.Phone == Supplier.Phone)
                        {
                            flag = true;
                        }
                    }
                }
                if (!flag)
                {
                    Context.Supplier.Add(Supplier);
                }
                Context.SaveChanges();


                nametextbox.Text = null;
                phonetextbox.Text = null;


                GridText.ItemsSource = null;

                GridText.ItemsSource = Context.Supplier.ToList();
            }
            else
            {
                MessageBox.Show("Please Enter Right Data");
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            supplier Supplier = GridText.SelectedItem as supplier;
            if (Supplier != null)
            {
                var spp = Context.Supplier.Where(s => s.Id == s.Id).Select(N => new {Name = N.Name, Phone = N.Phone }).ToList();
                Supplier.Name = nametextbox.Text;
                Supplier.Phone = phonetextbox.Text;

                Context.SaveChanges();
                GridText.ItemsSource = null;

                GridText.ItemsSource = Context.Supplier.ToList();
                GridText.SelectedItem = null;


            }
            else
            {
                MessageBox.Show("Please select row");
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            supplier Supplier = GridText.SelectedItem as supplier;
            if (Supplier != null)
            {
                supplier supplier = Context.Supplier.Where(e => e.Id == Supplier.Id).FirstOrDefault();

                Context.Supplier.Remove(supplier);

                Context.SaveChanges();
                nametextbox.Text = null;
                phonetextbox.Text = null;

                GridText.ItemsSource = null;

                GridText.ItemsSource = Context.Supplier.ToList();
            }
            else
            {
                MessageBox.Show("Please select row ");
            }
        }
    }
}