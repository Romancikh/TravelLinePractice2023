using NUnit.Framework;

namespace Shapes.Tests
{
    [TestFixture]
    public class TriangleTests
    {
        [Test]
        public void CalculateArea_WithValidSideLengths_ReturnsCorrectArea()
        {
            // Arange
            double side1 = 5;
            double side2 = 6;
            double side3 = 7;
            Triangle triangle = new( side1, side2, side3 );

            // Act
            double area = triangle.CalculateArea();

            // Assert
            double semiperimeter = triangle.CalculatePerimeter() / 2;
            double expectedArea = Math.Sqrt( semiperimeter * ( semiperimeter - side1 ) * ( semiperimeter - side2 ) * ( semiperimeter - side3 ) );
            Assert.AreEqual( expectedArea, area );
        }

        [Test]
        public void CalculatePerimeter_WithValidSideLengths_ReturnsCorrectPerimeter()
        {
            // Arange
            double side1 = 5;
            double side2 = 6;
            double side3 = 7;
            Triangle triangle = new( side1, side2, side3 );

            // Act
            double perimeter = triangle.CalculatePerimeter();

            // Assert
            double expectedPerimeter = side1 + side2 + side3;
            Assert.AreEqual( expectedPerimeter, perimeter );
        }
    }
}
