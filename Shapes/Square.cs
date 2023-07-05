namespace Shapes
{
    public class Square : IShape
    {
        private double _sideLength;
        public double SideLength
        {
            get { return _sideLength; }
            set
            {
                if ( value <= 0 )
                    throw new ArgumentException( "Side length must be a positive value." );
                _sideLength = value;
            }
        }
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
