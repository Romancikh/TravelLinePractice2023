class Program
{
    static List<T> BubbleSort<T>( List<T> unsortedList ) where T : IComparable<T>
    {
        List<T> sortedList = new( unsortedList );
        for ( int i = 1; i < sortedList.Count; i++ )
        {
            bool swapped = false;
            for ( int j = 0; j < sortedList.Count - i; j++ )
            {
                if ( sortedList[ j + 1 ].CompareTo( sortedList[ j ] ) < 0 )
                {
                    (sortedList[ j ], sortedList[ j + 1 ]) = (sortedList[ j + 1 ], sortedList[ j ]);
                    swapped = true;
                }
            }
            if ( !swapped )
            {
                return sortedList;
            }
        }
        return sortedList;
    }
    static void Main( string[] args )
    {
        List<int> unsortedList = new()
        {
            5, 9, 1, 8, 2, 7, 4, 6, 3, 10, 5, 11, 4
        };
        List<int> sortedList = BubbleSort( unsortedList );
        Console.WriteLine( $"Unsorted list: {string.Join( ", ", unsortedList )}" );
        Console.WriteLine( $"Sorted list: {string.Join( ", ", sortedList )}" );
    }
}