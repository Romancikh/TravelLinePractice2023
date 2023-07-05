namespace Shapes
{
    public class Square : IShape
    {
        public double SideLength { get; set; }
        public Square( double sideLength )
        {
            SideLength = sideLength;
        }
        public double CalculateArea()
        {
            return SideLength * SideLength;
        }

        public double CalculatePerimeter()
        {
            return 4 * SideLength;
        }
    }
}
