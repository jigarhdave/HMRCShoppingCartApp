using HMRCShoppingCart.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HMRCShoppingCart.Service.Interfaces
{   
    public interface IProductCollection
    {
        Product GetProductById(int id);
        Product GetProductByName(string productName);
    }
}
