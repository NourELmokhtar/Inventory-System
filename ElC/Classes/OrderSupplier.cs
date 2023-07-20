using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElC.Classes
{
    public class OrderSupplier
    {
        public int Id { get; set; }

        [ForeignKey("Supplier")]
        public int SupplierID;
        public DateTime Date { get; set; }
        public double Payed { get; set; }
        public double Total { get; set; }
        public double Reminder { get; set; }
        public virtual supplier Supplier { get; set; }
        public virtual List<OrderItemSupplier> Items { get; set; }


    }
}
