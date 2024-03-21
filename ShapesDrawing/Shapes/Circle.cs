namespace ShapesDrawing.Shapes;

class Circle : Shape
{
    private double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public override void Draw()
    {
        Console.WriteLine("\u25cb");
    }

    public override double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }

    public override double CalculatePerimeter()
    {
        return 2 * Math.PI * Radius;
    }
}
