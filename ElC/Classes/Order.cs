using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElC.Classes
{
    public class Order
    {

        public int Id { get; set; }

        [ForeignKey("Customer")]
        public int CustId { get; set; }

        [ForeignKey("Cashier")]
        public int CashierID { get; set; }

        public DateTime Date { get; set; }
        public double Payed { get; set; }
        public double Total { get; set; }
        public double Reminder { get; set; }
        public virtual customer Customer { get; set; }
        public virtual Cashier Cashier { get; set; }
        public List<OrderItem> Items { get; set; }

    }
}
