using System;
using System.Collections.Generic;
using System.Text;

namespace HMRCShoppingCart.Service.Models
{
    public class CalculateTotal
    {        
        public decimal Total { get; set; }

        public IList<CalculateProductTotal> CalculateProductTotal { get; set; }
    }
}
