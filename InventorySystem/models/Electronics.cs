namespace InventorySystem.models;

class Electronics : Item
{
    public string Manufacturer { get; set; }

    public Electronics(string name, double price, string manufacturer) : base(name, price)
    {
        Manufacturer = manufacturer;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Type: Electronics, Name: {Name}, Manufacturer: {Manufacturer}, Price: {Price:C}");
    }
}