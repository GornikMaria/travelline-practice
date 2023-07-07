public interface IShape
{
    double CalculateArea();
    double CalculatePerimeter();
}

public class Square : IShape
{
    private double sideLength;

    public Square(double sideLength)
    {
        if (sideLength < 0)
        {
            throw new ArgumentException("Длина стороны не может быть отрицательной.");
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

public class Triangle : IShape
{
    private double sideA;
    private double sideB;
    private double sideC;

    public Triangle(double sideA, double sideB, double sideC)
    {
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

public class Circle : IShape
{
    private double radius;

    public Circle(double radius)
    {
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
