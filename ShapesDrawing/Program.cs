namespace ShapesDrawing;

using Shapes;

class Program
{
    public static void Main(string[] args)
    {
        Circle circle = new Circle(5);
        Rectangle rectangle = new Rectangle(8, 2);
        
        Console.WriteLine("Shapes Information:");
        DrawAndCalculate(circle);
        DrawAndCalculate(rectangle);
    }

    static void DrawAndCalculate(IShape shape)
    {
        shape.Draw();
        Console.WriteLine($"Area: {shape.CalculateArea()}, Perimeter: {shape.CalculatePerimeter()}");
    }
}