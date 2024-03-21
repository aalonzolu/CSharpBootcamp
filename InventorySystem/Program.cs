
using InventorySystem.models;

class Program
{
    static void Main(string[] args)
    {
        Book book = new Book("Avatar the Last Airbender", 100, "Michael Dante DiMartino");
        Furniture furniture = new Furniture("Chair", 50, "Pine tree");
        Electronics electronics = new Electronics("S22 Ultra", 700, "Samsung");
        
        Console.WriteLine("Item Information:");
        book.DisplayInfo();
        furniture.DisplayInfo();
        electronics.DisplayInfo();
    }
}