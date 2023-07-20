using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElC.Classes
{
    public class OrderItemSupplier
    {
        public int ID { get; set; }
        [ForeignKey("OrderSupplier")]
        public int OrderSupplierID { get; set; }
        [ForeignKey("Product")]
        public int ProductID { get; set; }
        public int Count { get; set; }
        public virtual OrderSupplier OrderSupplier { get; set; }

        public virtual Product Product { get; set; }
    }
}
