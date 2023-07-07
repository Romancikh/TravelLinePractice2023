using NUnit.Framework;

namespace Shapes.Tests
{
    [TestFixture]
    public class SquareTests
    {
        [Test]
        public void CalculateArea_WithValidSideLength_ReturnsCorrectArea()
        {
            // Arrange
            double sideLength = 5;
            Square square = new( sideLength );

            // Act
            double area = square.CalculateArea();

            // Assert
            double expectedArea = 25;
            Assert.AreEqual( expectedArea, area );
        }

        [Test]
        public void CalculatePerimeter_WithValidSideLength_ReturnsCorrectPerimeter()
        {
            // Arrange
            double sideLength = 5;
            Square square = new( sideLength );

            // Act
            double perimeter = square.CalculatePerimeter();

            // Assert
            double expectedPerimeter = 20;
            Assert.AreEqual( expectedPerimeter, perimeter );
        }
    }
}
