using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Data.Test;
using FlooringMastery.Models;

namespace FlooringMastery.BLL
{
    public class ProductManager
    {
        private IProductInformationRepository _myProductInformationRepository;

        public ProductManager(IProductInformationRepository productInformationRepository)
        {
            _myProductInformationRepository = productInformationRepository;
        }

        public List<Product> ListAll()
        {
            return _myProductInformationRepository.ListAll();
        }

        public bool IsValidProduct(string productName)
        {
            var allProducts = _myProductInformationRepository.ListAll();

            return allProducts.Any(p => p.ProductType == productName);
        }

        public Product GetSingleProduct(string productName)
        {
            var allProducts = _myProductInformationRepository.ListAll();

            foreach (var product in allProducts)
            {
                if (product.ProductType == productName)
                {
                    return product;
                }
            }
            return null;
        }
    }
}
