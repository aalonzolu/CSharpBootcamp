namespace ShapesDrawing.Shapes;


abstract class Shape : IShape
{
    public abstract void Draw();
    public abstract double CalculateArea();
    public abstract double CalculatePerimeter();
}