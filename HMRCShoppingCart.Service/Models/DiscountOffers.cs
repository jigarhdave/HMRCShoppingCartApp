using HMRCShoppingCart.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HMRCShoppingCart.Service.Models
{
    public class DiscountOffers : IDiscount
    {
        private readonly string _productName;
        private int _discountOnQty;

        public DiscountOffers(string productName, int discountOnQty)
        {
            _productName = productName;
            _discountOnQty = discountOnQty;
        }
        public IList<CalculateProductTotal> ApplyDiscount(IList<CalculateProductTotal> products)
        {
            var discountProduct = products.FirstOrDefault(x => x.ShoppingCartItem.Product.Name == _productName);

            if (discountProduct != null)
            {
                var numberOfFreeProducts = discountProduct.ShoppingCartItem.Qty / _discountOnQty;

                discountProduct.Discount = numberOfFreeProducts * discountProduct.ShoppingCartItem.Product.Price;
            }

            return products;
        }

        public bool IsDiscountApplicable(IList<CalculateProductTotal> products)
        {
            return products.Any(x => x.ShoppingCartItem.Product.Name == _productName && x.ShoppingCartItem.Qty >= _discountOnQty);
        }
    }
}
