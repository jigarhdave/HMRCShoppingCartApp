using HMRCShoppingCart.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HMRCShoppingCart.Service.Models
{
    public class ProductCollection : IProductCollection
    {
        private IList<Product> products;

        public ProductCollection(IList<Product> products)
        {
            this.products = products;
        }
        public Product GetProductById(int id)
        {
            return products.FirstOrDefault(x => x.Id == id);
        }

        public Product GetProductByName(string Name)
        {
            return products.FirstOrDefault(x => x.Name == Name);
        }
    }
}
