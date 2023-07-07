using NUnit.Framework;

namespace Shapes.Tests
{
    [TestFixture]
    public class TriangleTests
    {
        [Test]
        public void Constructor_NegativeSideLengths_ThrowsArgumentException()
        {
            // Arrange, Act, Assertion
            Assert.Throws<ArgumentException>( () => new Triangle( -1, -1, -1 ) );
        }

        [Test]
        public void Constructor_ZeroSideLengths_ThrowsArgumentException()
        {
            // Arrange, Act, Assertion
            Assert.Throws<ArgumentException>( () => new Triangle( 0, 0, 0) );
        }

        [Test]
        public void Constructor_WrongSideLengths_ThrowsArgumentException()
        {
            // Arrange, Act, Assertion
            Assert.Throws<ArgumentException>( () => new Triangle( 1, 2, 4 ) );
        }

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
