using NUnit.Framework;

namespace Shapes.Tests
{
    [TestFixture]
    public class CircleTests
    {
        [Test]
        public void CalculateArea_WithValidRadius_ReturnsCorrectArea()
        {
            // Arrange
            double radius = 5;
            Circle circle = new( radius );

            // Act
            double area = circle.CalculateArea();

            // Assert
            double expectedArea = 78.53982;
            Assert.AreEqual( expectedArea, area, 0.00001 );
        }

        [Test]
        public void CalculatePerimeter_WithValidRadius_ReturnsCorrectPerimeter()
        {
            // Arrange
            double radius = 5;
            Circle circle = new( radius );

            // Act
            double perimeter = circle.CalculatePerimeter();

            // Assert
            double expectedPerimeter = 31.41593;
            Assert.AreEqual( expectedPerimeter, perimeter, 0.00001 );
        }
    }
}
