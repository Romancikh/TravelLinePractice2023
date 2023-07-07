class Program
{
    static List<T> BubbleSort<T>(List<T> list) where T : IComparable<T>
    {
        for (int i = 1; i < list.Count; i++)
        {
            bool swapped = false;
            for (int j = 0; j < list.Count - i; j++)
            {
                if (list[j + 1].CompareTo(list[j]) < 0)
                {
                    (list[j], list[j + 1]) = (list[j + 1], list[j]);
                    swapped = true;
                }
            }
            if (!swapped)
            {
                return list;
            }
        }
        return list;
    }
    static void Main(string[] args)
    {
        List<int> unsortedList = new()
        {
            5, 9, 1, 8, 2, 7, 4, 6, 3, 10, 5, 11, 4
        };
        List<int> sortedList = BubbleSort(unsortedList);
        Console.WriteLine(string.Join(", ", sortedList ));
    }
}