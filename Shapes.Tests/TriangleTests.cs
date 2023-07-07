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
            Triangle triangle = new( 5, 6, 7 );

            // Act
            double area = triangle.CalculateArea();

            // Assert
            Assert.AreEqual( 14.69694, area, 0.00001 );
        }

        [Test]
        public void CalculatePerimeter_WithValidSideLengths_ReturnsCorrectPerimeter()
        {
            // Arange
            Triangle triangle = new( 5, 6, 7 );

            // Act
            double perimeter = triangle.CalculatePerimeter();

            // Assert
            Assert.AreEqual( 18, perimeter );
        }
    }
}
