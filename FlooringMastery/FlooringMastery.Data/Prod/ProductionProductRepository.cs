using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;
using System.IO;

namespace FlooringMastery.Data.Prod
{
    public class ProductionProductRepository : IProductInformationRepository
    {
        public List<Product> ListAll()
        {
            List<Product> products = new List<Product>();

            var list = File.ReadAllLines(@"DataFiles/Products.txt");

            for (int i = 1; i < list.Length; i++)
            {
                var columns = list[i].Split(',');

                var product = new Product();

                product.ProductType = columns[0];
                product.CostPerSquareFoot = decimal.Parse(columns[1]);
                product.LaborCostPerSquareFoot = decimal.Parse(columns[2]);

                products.Add(product);
            }
            return products;
        }
    }
}
