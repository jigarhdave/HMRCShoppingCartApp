using HMRCShoppingCart.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HMRCShoppingCart.Service.Models
{    
     public class ShoppingCart
    {
        private readonly IProductCollection productCollection;

        public  IList<ShoppingCartItem> Items = new List<ShoppingCartItem>();

        public ShoppingCart(IProductCollection productCollection)
        {            
            this.productCollection = productCollection;            
        }             

        public void AddProduct(string Name, int qty)
        {
            if (!string.IsNullOrEmpty(Name) && qty > 0)
            {
                var product = productCollection.GetProductByName(Name);

                var itemByProduct = Items.FirstOrDefault(x => x.Product.Name == product.Name);

                if (itemByProduct == null)
                {
                    Items.Add(new ShoppingCartItem { Product = product, Qty = qty });
                }
                else
                {
                    itemByProduct.Qty += qty;
                }
            }
        }

        public CalculateTotal CalculateTotal()
        {

            IList<CalculateProductTotal> calculateProductTotal = new List<CalculateProductTotal>(
                Items.Select(x => new CalculateProductTotal(x)));

            //prepare the result object
            var calculation = new CalculateTotal
            {
                Total = calculateProductTotal.Sum(x => (x.ProductsTotal)),
                CalculateProductTotal = calculateProductTotal
            };

            return calculation;
        }
    }

}
