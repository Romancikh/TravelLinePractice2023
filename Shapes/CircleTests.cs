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
            double expectedArea = Math.PI * radius * radius;
            Assert.AreEqual( expectedArea, area );
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
            double expectedPerimeter = 2 * Math.PI * radius;
            Assert.AreEqual( expectedPerimeter, perimeter );
        }
    }
}
