namespace Shapes
{
    public class Triangle : IShape
    {
        private double _side1;
        private double _side2;
        private double _side3;

        public double Side1
        {
            get { return _side1; }
            private set
            {
                if ( value <= 0 )
                    throw new ArgumentException( "Side1 must be a positive value." );
                _side1 = value;
            }
        }

        public double Side2
        {
            get { return _side2; }
            private set
            {
                if ( value <= 0 )
                    throw new ArgumentException( "Side2 must be a positive value." );
                _side2 = value;
            }
        }

        public double Side3
        {
            get { return _side3; }
            private set
            {
                if ( value <= 0 )
                    throw new ArgumentException( "Side3 must be a positive value." );
                _side3 = value;
            }
        }

        public Triangle( double side1, double side2, double side3 )
        {
            Side1 = side1;
            Side2 = side2;
            Side3 = side3;

            if ( !IsTriangleValid() )
            {
                throw new ArgumentException( "Triangle with the given side lengths does not exist." );
            }
        }

        private bool IsTriangleValid()
        {
            return Side1 + Side2 > Side3 && Side1 + Side3 > Side2 && Side2 + Side3 > Side1;
        }

        public double CalculateArea()
        {
            double semiperimeter = CalculatePerimeter() / 2;
            return Math.Sqrt( semiperimeter * ( semiperimeter - Side1 ) * ( semiperimeter - Side2 ) * ( semiperimeter - Side3 ) );
        }

        public double CalculatePerimeter()
        {
            return Side1 + Side2 + Side3;
        }
    }
}