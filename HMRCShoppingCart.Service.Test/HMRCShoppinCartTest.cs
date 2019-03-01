using HMRCShoppingCart.Service.Interfaces;
using HMRCShoppingCart.Service.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace HMRCShoppingCart.Service.Test
{
    [TestClass]
    public class HMRCShoppinCartTest
    {
        [TestMethod]
        public void Should_Return_ShoppingCart_Product_When_Added_Products_To_ShoppingCart()
        {
            //Arrange
            var products = new List<Product>();
            products.Add(new Product { Id = 1, Name = "Product 1", Price = 0.60M });
            products.Add(new Product { Id = 2, Name = "Product 2", Price = 25M });

            var productCollection = new ProductCollection(products);            

            var shoppingCart = new ShoppingCart(productCollection,null);

            //Action
            shoppingCart.AddProduct("Product 1", 2);
            shoppingCart.AddProduct("Product 2", 1);

            //Assert
            Assert.IsNotNull(shoppingCart);
            Assert.AreEqual(2, shoppingCart.Items.Count);
            Assert.AreEqual("Product 1",shoppingCart.Items.FirstOrDefault(x => x.Product.Id == 1).Product.Name);            
            Assert.AreEqual(products.FirstOrDefault(x => x.Id == 1).Name, shoppingCart.Items.FirstOrDefault(x => x.Product.Id == 1).Product.Name);
        }

        [TestMethod]
        public void Should_Retunt_ShoppingCart_Total_when_Calculate_Total_Products()
        {
            // Arrange
            var products = new List<Product>();
            products.Add(new Product { Name = "Product 1", Price = 10 });
            products.Add(new Product { Name = "Product 2", Price = 20 });
            products.Add(new Product { Name = "Product 3", Price = 30 });

            var productCollection = new ProductCollection(products);

            // ideally create mock discount object.
            var discounts = new List<IDiscount>(){};            
            var discountCollection = new DiscountCollection(discounts);

            var shoppingCartTest = new ShoppingCart(productCollection, discountCollection);

            shoppingCartTest.AddProduct("Product 1", 3);
            shoppingCartTest.AddProduct("Product 3", 3);

            //Action
            var calculation = shoppingCartTest.CalculateTotal();

            //Assert
            Assert.IsNotNull(calculation.Total);
            Assert.AreEqual(120M, calculation.Total);
        }


        [TestMethod]
        public void Should_Retunt_ShoppingCart_Total_After_Discount_when_Calculate_Total_Products_With_Discount_Offers()
        {
            // Arrange
            var products = new List<Product>();
            products.Add(new Product { Name = "Product 1", Price = 10 });
            products.Add(new Product { Name = "Product 2", Price = 20 });
            products.Add(new Product { Name = "Product 3", Price = 30 });

            var productCollection = new ProductCollection(products);

            // ideally create mock discount object.
            var discounts = new List<IDiscount>() {
                  new DiscountOffers("Product 1",2),
                  new DiscountOffers("Product 2",3),
            };
            var discountCollection = new DiscountCollection(discounts);

            var shoppingCartTest = new ShoppingCart(productCollection, discountCollection);

            shoppingCartTest.AddProduct("Product 1", 2);
            shoppingCartTest.AddProduct("Product 2", 3);

            //Action
            var calculation = shoppingCartTest.CalculateTotal();

            //Assert
            Assert.IsNotNull(calculation.Total);
            Assert.AreEqual(50M, calculation.Total);
        }
    }
}
