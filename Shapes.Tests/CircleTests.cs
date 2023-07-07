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
            Circle circle = new( 5 );

            // Act
            double area = circle.CalculateArea();

            // Assert
            Assert.AreEqual( 78.53982, area, 0.00001 );
        }

        [Test]
        public void CalculatePerimeter_WithValidRadius_ReturnsCorrectPerimeter()
        {
            // Arrange
            Circle circle = new( 5 );

            // Act
            double perimeter = circle.CalculatePerimeter();

            // Assert
            Assert.AreEqual( 31.41593, perimeter, 0.00001 );
        }
    }
}
