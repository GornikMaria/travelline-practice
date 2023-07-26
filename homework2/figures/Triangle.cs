using System;

public class Triangle : IShape
{
    private double sideA;
    private double sideB;
    private double sideC;

    public Triangle(double sideA, double sideB, double sideC)
    {
        if (sideA < 0 || sideB < 0 || sideC < 0)
        {
            throw new ArgumentException("Длина стороны не может быть отрицательной");
        }
        this.sideA = sideA;
        this.sideB = sideB;
        this.sideC = sideC;
    }

    public double CalculateArea()
    {
        double semiPerimeter = (sideA + sideB + sideC) / 2;
        //Формула Герона
        return Math.Sqrt(semiPerimeter * (semiPerimeter - sideA) * (semiPerimeter - sideB) * (semiPerimeter - sideC));
    }

    public double CalculatePerimeter()
    {
        return sideA + sideB + sideC;
    }
}