using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;

namespace FlooringMastery.Data.Test
{
    public class TestProductRepository : IProductInformationRepository
    {
        public List<Product> ListAll()
        {
            return new List<Product>
            {
                new Product() {ProductType = "Wood", CostPerSquareFoot = 5.15M, LaborCostPerSquareFoot = 4.75M},
                new Product() {ProductType = "Marble", CostPerSquareFoot = 15.00M, LaborCostPerSquareFoot = 7.50M},
                new Product() {ProductType = "Carpet", CostPerSquareFoot = 1.75M, LaborCostPerSquareFoot = 3.50M}
            };
        } 


    }
}
