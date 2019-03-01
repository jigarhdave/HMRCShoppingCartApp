using System;
using System.Collections.Generic;
using System.Text;

namespace HMRCShoppingCart.Service.Models
{
    public class CalculateProductTotal
    {
        public int Id { get; set; }

        public ShoppingCartItem _shoppingCartItem { get; set; }

        public CalculateProductTotal(ShoppingCartItem shoppingCartItem)
        {
            _shoppingCartItem = shoppingCartItem;
        }             

        public decimal ProductsTotal
        {
            get
            {
                return _shoppingCartItem.Product.Price * _shoppingCartItem.Qty ;
            }
        }
    }


}
