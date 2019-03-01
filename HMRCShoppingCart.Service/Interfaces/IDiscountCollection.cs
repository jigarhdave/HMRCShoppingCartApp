using System;
using System.Collections.Generic;
using System.Text;

namespace HMRCShoppingCart.Service.Interfaces
{
    public interface IDiscountCollection
    {
        IList<IDiscount> GetDiscounts();
    }
}
