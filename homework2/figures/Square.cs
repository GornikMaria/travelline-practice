using System;

public class Square : IShape
{
    private double sideLength;

    public Square(double sideLength)
    {
        if (sideLength < 0)
        {
            throw new ArgumentException("Длина стороны не может быть отрицательной");
        }

        this.sideLength = sideLength;
    }

    public double CalculateArea()
    {
        return sideLength * sideLength;
    }

    public double CalculatePerimeter()
    {
        return 4 * sideLength;
    }
}