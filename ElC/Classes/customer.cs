using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElC.Classes
{
    public class customer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Phone { get; set; }
        
        public virtual List<Order> customerBill { get; set; }

    }
}
