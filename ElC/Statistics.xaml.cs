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
{
    /// <summary>
    /// Interaction logic for Statistics.xaml
    /// </summary>
    public partial class Statistics : UserControl
    {
        InventoryEntity context = new InventoryEntity();
        public Statistics()
        {
            InitializeComponent();

            double SumProfit = 0;

            var profit = context.OrderItem.Include(o => o.Product);

            foreach (var item in profit)
            {
                SumProfit +=  (item.Product.SellPrice - item.Product.BuyPrice)*item.Count;
            }
            Profit.Text = SumProfit.ToString();

            Order order = context.Order.Include(p => p.Customer).OrderByDescending(p => p.Total).FirstOrDefault();
            customer customer = context.Customer.FirstOrDefault(c => c.Id == order.CustId);
            CustomerWithMostPrice.Text = customer.Name;

/*            var Mostproduct = context.OrderItem
*/
        }
    }
}
