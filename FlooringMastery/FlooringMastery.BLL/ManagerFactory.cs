using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using FlooringMastery.Data.Prod;
using FlooringMastery.Data.Test;
using FlooringMastery.Models;

namespace FlooringMastery.BLL
{
    public class ManagerFactory
    {
        public static TaxManager CreateTaxManager()
        {
            string mode = ConfigurationManager.AppSettings["mode"];

            if(mode == "test")
                return new TaxManager(new TestTaxInformationRepository());
            else
            {
                return new TaxManager(new ProductionTaxInformationRepository());
            }
        }

        public static ProductManager CreateProductManager()
        {
            string mode = ConfigurationManager.AppSettings["mode"];

            if (mode == "test")
                return new ProductManager(new TestProductRepository());
            else
            {
                return new ProductManager(new ProductionProductRepository());
            }
        }

        public static IOrderDataRepository CreateOrderManager()
        {
            string mode = ConfigurationManager.AppSettings["mode"];

            if (mode == "test")
                return new TestOrderRepository();
            else
            {
                return new OrderRepository();
            }
        }
    }
}
