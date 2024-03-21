namespace InventorySystem.models;

class Item
{
    public string Name { get; set; }
    public double Price { get; set; }

    public Item(string name, double price)
    {
        Name = name;
        Price = price;
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Name: {Name}, Price: {Price:C}");
    }
}