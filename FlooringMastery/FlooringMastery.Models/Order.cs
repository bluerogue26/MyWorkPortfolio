using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Models
{
    public class Order
    {
        public int OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public decimal Area { get; set; }
        public decimal MaterialCost { get; set; }
        public decimal LaborCost { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }
        public Product Product { get; set; }
        public Taxes Taxes { get; set; }
        public string Date { get; set; }

        public Order()
        {
            Taxes = new Taxes();
            Product = new Product();
        }
    }
}
