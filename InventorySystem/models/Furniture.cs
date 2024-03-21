namespace InventorySystem.models;

class Furniture : Item
{
    public string Material { get; set; }

    public Furniture(string name, double price, string material) : base(name, price)
    {
        Material = material;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Type: Furniture, Name: {Name}, Material: {Material}, Price: {Price:C}");
    }
}