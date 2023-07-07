using NUnit.Framework;

namespace Shapes.Tests
{
    [TestFixture]
    public class SquareTests
    {
        [Test]
        public void Constructor_NegativeSideLength_ThrowsArgumentException()
        {
            // Arrange, Act, Assertion
            Assert.Throws<ArgumentException>( () => new Square( -1 ) );
        }

        [Test]
        public void Constructor_ZeroSideLength_ThrowsArgumentException()
        {
            // Arrange, Act, Assertion
            Assert.Throws<ArgumentException>( () => new Square( 0 ) );
        }

        [Test]
        public void CalculateArea_WithValidSideLength_ReturnsCorrectArea()
        {
            // Arrange
            Square square = new( 5 );

            // Act
            double area = square.CalculateArea();

            // Assert
            Assert.AreEqual( 25, area );
        }

        [Test]
        public void CalculatePerimeter_WithValidSideLength_ReturnsCorrectPerimeter()
        {
            // Arrange
            Square square = new( 5 );

            // Act
            double perimeter = square.CalculatePerimeter();

            // Assert
            Assert.AreEqual( 20, perimeter );
        }
    }
}
