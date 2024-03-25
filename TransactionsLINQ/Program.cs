using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesTransactionAnalysis
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a list of sales transactions
            List<Transaction> transactions = new List<Transaction>
            {
                new Transaction { TransactionId = 1, ProductId = 101, Quantity = 2, Price = 10.50 },
                new Transaction { TransactionId = 2, ProductId = 102, Quantity = 1, Price = 25.75 },
                new Transaction { TransactionId = 3, ProductId = 101, Quantity = 3, Price = 10.50 },
                new Transaction { TransactionId = 4, ProductId = 103, Quantity = 2, Price = 15.00 },
                new Transaction { TransactionId = 5, ProductId = 102, Quantity = 4, Price = 25.75 }
            };
            
            IEnumerable<ProductSales> salesByProduct = from t in transactions
                group t by t.ProductId into g
                select new ProductSales
                {
                    ProductId = g.Key,
                    TotalSales = g.Sum(t => t.Quantity * t.Price)
                };

            // Output results to the console
            Console.WriteLine("Product ID\tTotal Sales");
            foreach (var result in salesByProduct)
            {
                Console.WriteLine($"{result.ProductId}\t\t{result.TotalSales:C}");
            }
        }
    }
    
}