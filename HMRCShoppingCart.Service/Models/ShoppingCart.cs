using HMRCShoppingCart.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HMRCShoppingCart.Service.Models
{    
     public class ShoppingCart
    {
        private readonly IProductCollection _productCollection;
        private readonly IDiscountCollection _discountCollection;

        public  IList<ShoppingCartItem> Items = new List<ShoppingCartItem>();

        public ShoppingCart(IProductCollection productCollection , IDiscountCollection discountCollection)
        {            
            _productCollection = productCollection;
            _discountCollection = discountCollection;
        }             

        public void AddProduct(string Name, int qty)
        {
            if (!string.IsNullOrEmpty(Name) && qty > 0)
            {
                var product = _productCollection.GetProductByName(Name);

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


            var discounts = _discountCollection.GetDiscounts();

            var appliedDiscounts = new List<IDiscount>();
            foreach (var discount in discounts)
            {
                if (discount.IsDiscountApplicable(calculateProductTotal))
                {
                    appliedDiscounts.Add(discount);
                    calculateProductTotal = (discount.ApplyDiscount(calculateProductTotal));
                }
            }
           
            var calculation = new CalculateTotal
            {
                Total = calculateProductTotal.Sum(x => (x.ProductsTotal)),
                CalculateProductTotal = calculateProductTotal
            };

            return calculation;
        }
    }

}
