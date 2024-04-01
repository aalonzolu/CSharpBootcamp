using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BookStoreConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string baseUrl = "http://localhost:5203/api";
            
            var random = new Random();
            
            Book newBook = new Book
            {
                Title = "New Book " + random.Next(1, 100),
                Author = "Author Name " + random.Next(1, 100)
            };

            await CreateBookAsync(baseUrl, newBook);
            
            await ListBooksAsync(baseUrl);
        }

        static async Task CreateBookAsync(string baseUrl, Book book)
        {
            using (HttpClient client = new HttpClient())
            {
                string json = JsonConvert.SerializeObject(book);
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(baseUrl + "/books", content);
                
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("New book created successfully.");
                }
                else
                {
                    Console.WriteLine($"Failed to create book. Status code: {response.StatusCode}");
                }
            }
        }

        static async Task ListBooksAsync(string baseUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(baseUrl + "/books");
                
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    List<Book> books = JsonConvert.DeserializeObject<List<Book>>(json);
                    
                    Console.WriteLine("Existing Books:");
                    foreach (var book in books)
                    {
                        Console.WriteLine($"Title: {book.Title}, Author: {book.Author}");
                    }
                }
                else
                {
                    Console.WriteLine($"Failed to retrieve books. Status code: {response.StatusCode}");
                }
            }
        }
    }
    
    
}
