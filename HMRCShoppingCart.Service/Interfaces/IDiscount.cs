using HMRCShoppingCart.Service.Models;
using System.Collections.Generic;

namespace HMRCShoppingCart.Service.Interfaces
{
    public interface IDiscount
    {
        bool IsDiscountApplicable(IList<CalculateProductTotal> products);
        IList<CalculateProductTotal> ApplyDiscount(IList<CalculateProductTotal> products);
    }
}
