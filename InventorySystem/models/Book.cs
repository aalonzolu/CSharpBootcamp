namespace InventorySystem.models;

class Book : Item
{
    public string Author { get; set; }

    public Book(string name, double price, string author) : base(name, price)
    {
        Author = author;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Type: Book, Name: {Name}, Author: {Author}, Price: {Price:C}");
    }
}