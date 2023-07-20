using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElC.Classes
{
    public class ReturnCustomerProduct
    {
        public int ID { get; set; }

        [ForeignKey("Order")]
        public int OrderID { get; set; }


        public int Count { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("Product")]
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}
