using System;

public class Circle : IShape
{
    private double radius;

    public Circle(double radius)
    {
        if (radius < 0)
        {
            throw new ArgumentException("Радиус не может быть отрицательным");
        }
        this.radius = radius;
    }

    public double CalculateArea()
    {
        return Math.PI * radius * radius;
    }

    public double CalculatePerimeter()
    {
        return 2 * Math.PI * radius;
    }
}