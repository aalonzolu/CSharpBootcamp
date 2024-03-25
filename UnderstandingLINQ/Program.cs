using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductFilterAndSort;
using models;

class Program
    {
        static void Main(string[] args)
        {
            // Create a list of products
            List<Product> products = new List<Product>
            {
                new Product { Id = 1, Name = "Laptop", Category = "Electronics", Price = 999.99 },
                new Product { Id = 2, Name = "Smartphone", Category = "Electronics", Price = 599.99 },
                new Product { Id = 3, Name = "T-shirt", Category = "Clothing", Price = 19.99 },
                new Product { Id = 4, Name = "Jeans", Category = "Clothing", Price = 39.99 },
                new Product { Id = 5, Name = "Headphones", Category = "Electronics", Price = 49.99 },
                new Product { Id = 6, Name = "Sneakers", Category = "Footwear", Price = 79.99 },
            };
            
            // Get all categories names using LINQ
            var categories = from p in products
                             select p.Category;
            
            // remove duplicates
            categories = categories.Distinct();
            
            // iterate over all categories
            var enumerable = categories.ToList();
            for (int i = 0; i < enumerable.Count(); i++)
            {
                var category = enumerable.ElementAt(i);
                
                var filteredProducts = from p in products
                    where p.Category == category
                    select p;
                
                var sortedProducts = from p in filteredProducts
                    orderby p.Price
                    select p;
                
                Console.WriteLine($"Filtered and Sorted Products in Category: {category}");
                foreach (var product in sortedProducts)
                {
                    Console.WriteLine($"Id: {product.Id}, Name: {product.Name}, Price: ${product.Price}");
                }
            }
            
            
        }
    }
    