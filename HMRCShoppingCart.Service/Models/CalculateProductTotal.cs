using System;
using System.Collections.Generic;
using System.Text;

namespace HMRCShoppingCart.Service.Models
{
    public class CalculateProductTotal
    {
        public int Id { get; set; }

        public ShoppingCartItem ShoppingCartItem { get; set; }

        public decimal Discount { get; set; }

        public CalculateProductTotal(ShoppingCartItem shoppingCartItem)
        {
            ShoppingCartItem = shoppingCartItem;
        }             

        public decimal ProductsTotal
        {
            get
            {
                return ShoppingCartItem.Product.Price * ShoppingCartItem.Qty - Discount;
            }
        }
    }


}
