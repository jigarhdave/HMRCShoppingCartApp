﻿using HMRCShoppingCart.Service.Interfaces;
using HMRCShoppingCart.Service.Models;
using System;
using System.Collections.Generic;

namespace HMRCShoppingCartApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var products = new List<Product>()
                {
                    new Product { Id = 1, Name = "Apple", Price = 0.60M},
                    new Product { Id = 2, Name = "Orange", Price = 0.25M}
                };

            var discounts = new List<IDiscount>()
                {
                    new DiscountOffers("Apple",2),
                    new DiscountOffers("Orange",3),                    
                };


            var shoppingCart = new ShoppingCart(new ProductCollection(products), new DiscountCollection(discounts));

            Console.WriteLine("Case 1:");
            shoppingCart.AddProduct("Apple", 1);
            shoppingCart.AddProduct("Orange", 1);
            var result = shoppingCart.CalculateTotal();
            DisplayResult(result);



            shoppingCart = new ShoppingCart(new ProductCollection(products), new DiscountCollection(discounts));
            Console.WriteLine("Case 2:");
            shoppingCart.AddProduct("Apple", 2);
            shoppingCart.AddProduct("Orange", 3);            
            result = shoppingCart.CalculateTotal();
            DisplayResult(result);

            shoppingCart = new ShoppingCart(new ProductCollection(products), new DiscountCollection(discounts));
            Console.WriteLine("Case 3:");
            shoppingCart.AddProduct("Apple", 3);
            shoppingCart.AddProduct("Orange", 4);
            
            result = shoppingCart.CalculateTotal();
            DisplayResult(result);

            Console.ReadLine();
        }

        private static void DisplayResult(CalculateTotal calculation)
        {
            foreach (var item in calculation.CalculateProductTotal)
            {
                Console.WriteLine();
                Console.WriteLine(":: Product :: ");
                Console.WriteLine();
                Console.WriteLine("Name:= " + item.ShoppingCartItem.Product.Name);
                Console.WriteLine("Price:= " + item.ShoppingCartItem.Product.Price);
                Console.WriteLine("Quantity:= " + item.ShoppingCartItem.Qty);
                Console.WriteLine("Discount:= " + item.Discount);
                Console.WriteLine();
                Console.WriteLine("Total:= " + item.ProductsTotal);
                Console.WriteLine();

            }

            Console.WriteLine();
            Console.WriteLine("Total Shopping Cart ==>> " + calculation.Total);
            Console.WriteLine();
        }

    }

}