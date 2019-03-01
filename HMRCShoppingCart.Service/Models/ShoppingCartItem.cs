using System;
using System.Collections.Generic;
using System.Text;

namespace HMRCShoppingCart.Service.Models
{
    public class ShoppingCartItem
    {       
        public int Id { get; set; }
        public Product Product { get; set; }
        public int Qty { get; set; }        
    }
}
