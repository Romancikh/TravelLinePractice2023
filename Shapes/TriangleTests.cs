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
            double expectedArea = 14.69694;
            Assert.AreEqual( expectedArea, area, 0.00001 );
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
            double expectedPerimeter = 18;
            Assert.AreEqual( expectedPerimeter, perimeter );
        }
    }
}
