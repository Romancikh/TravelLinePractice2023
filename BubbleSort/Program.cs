class Program
{
    static List<T> BubbleSort<T>(List<T> list) where T : IComparable<T>
    {
        for (int i = 0; i < list.Count; i++)
        {
            for (int j = 0; j < list.Count; j++)
            {
                if (list[i].CompareTo(list[j]) < 0)
                {
                    (list[i], list[j]) = (list[j], list[i]);
                }
            }
        }
        return list;
    }
    static void Main(String[] args)
    {
        List<int> unsortedList = new()
        {
            5, 9, 1, 8, 2, 7, 4, 6, 3, 10, 5, 11, 4
        };
        List<int> sortedList = Program.BubbleSort(unsortedList);
        sortedList.ForEach(item => Console.WriteLine(item));
    }
}