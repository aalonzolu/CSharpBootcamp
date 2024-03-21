namespace ShapesDrawing.Shapes;

class Rectangle : Shape
{
    private double Length { get; set; }
    private double Width { get; set; }

    public Rectangle(double length, double width)
    {
        Length = length;
        Width = width;
    }

    public override void Draw()
    {
        Console.WriteLine("\u25ad");
    }

    public override double CalculateArea()
    {
        return Length * Width;
    }

    public override double CalculatePerimeter()
    {
        return 2 * (Length + Width);
    }
}