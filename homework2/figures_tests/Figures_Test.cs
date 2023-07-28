using NUnit.Framework;

namespace figures_tests
{
    [TestFixture]
    public class FiguresTest
    {
        private Square square;
        private Triangle triangle;
        private Circle circle;

        [SetUp]
        public void Setup()
        {
            double sideLength = 5;
            square = new Square(sideLength);

            double sideA = 3;
            double sideB = 4;
            double sideC = 5;
            triangle = new Triangle(sideA, sideB, sideC);

            double radius = 4;
            circle = new Circle(radius);
        }

        [Test]
        public void CalculateAreaSquare()
        {
            // Arrange
            double expectedArea = 25;

            // Act
            double actualArea = square.CalculateArea();

            // Assert
            Assert.AreEqual(expectedArea, actualArea);
        }
        
        [Test]
        public void CalculatePerimeterSquare()
        {
            // Arrange
            double expectedPerimeter = 20;

            // Act
            double actualPerimeter = square.CalculatePerimeter();

            // Assert
            Assert.AreEqual(expectedPerimeter, actualPerimeter);
        }
        
        [Test]
        public void CalculateAreaTriangle()
        {
            // Arrange
            double expectedArea = 6;

            // Act
            double actualArea = triangle.CalculateArea();

            // Assert
            Assert.AreEqual(expectedArea, actualArea);
        }

        [Test]
        public void CalculatePerimeterTriangle()
        {
            // Arrange
            double expectedPerimeter = 12;

            // Act
            double actualPerimeter = triangle.CalculatePerimeter();

            // Assert
            Assert.AreEqual(expectedPerimeter, actualPerimeter);
        }

        [Test]
        public void CalculateAreaCircle()
        {
            // Arrange
            double expectedArea = 50.265;

            // Act
            double actualArea = circle.CalculateArea();

            // Assert
            Assert.AreEqual(expectedArea, actualArea, 0.001);
        }

        [Test]
        public void CalculatePerimeterCircle()
        {
            // Arrange
            double expectedPerimeter = 25.132;

            // Act
            double actualPerimeter = circle.CalculatePerimeter();

            // Assert
            Assert.AreEqual(expectedPerimeter, actualPerimeter, 0.001);
        }
    }
}
