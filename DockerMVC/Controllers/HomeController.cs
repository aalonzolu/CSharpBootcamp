using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DockerMVC.Models;

namespace DockerMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    
    private List<Book> FetchBooks()
    {
        String booksEndpoint = System.Environment.GetEnvironmentVariable("BOOKS_BASE_URL") ?? "http://localhost:8080";
        try
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(booksEndpoint);
            var response = client.GetAsync("/books").Result;
            var books = response.Content.ReadFromJsonAsync<List<Book>>().Result;
            return books is { Count: > 0 } ? books : [];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return [];
        }
        
        
    }

    public IActionResult Index()
    {
        ViewBag.Books = this.FetchBooks();
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}