using HMRCShoppingCart.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HMRCShoppingCart.Service.Models
{
    public class DiscountCollection : IDiscountCollection
    {
        private IList<IDiscount> _discounts;

        public DiscountCollection(IList<IDiscount> discounts)
        {
            _discounts = discounts;
        }

        public IList<IDiscount> GetDiscounts()
        {
            return _discounts;
        }
    }
}
