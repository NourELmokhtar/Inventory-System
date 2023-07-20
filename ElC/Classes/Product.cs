using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElC.Classes
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public double BuyPrice { get; set; }
        public double SellPrice { get; set; }
        public int Quantaty { get; set; }
        public string Description { get; set; }
        //
        [ForeignKey("Category")]
        public int CategoryID { get; set; }

        [ForeignKey("Supplier")]
        public int SupplierID { get; set; }

        public bool Exist { get; set; }
        public virtual Category Category { get; set; }
        public virtual supplier Supplier { get; set; }
    }
}
