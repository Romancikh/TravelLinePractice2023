namespace Shapes
{
    internal class Circle : IShape
    {
        private double _radius;

        public double Radius
        {
            get { return _radius; }
            set
            {
                if ( value <= 0 )
                    throw new ArgumentException( "Side length must be a positive value." );
                _radius = value;
            }
        }

        public Circle( double radius )
        {
            Radius = radius;
        }

        public double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }

        public double CalculatePerimeter()
        {
            return 2 * Math.PI * Radius;
        }
    }
}
