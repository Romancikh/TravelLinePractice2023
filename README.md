# BubbleSort
## Описание
Проект "BubbleSort" представляет собой реализацию алгоритма сортировки пузырьком на языке программирования C#. Алгоритм позволяет упорядочить массив элементов в порядке возрастания.
## Пример использования
```csharp
List<int> unsortedList = new() { 5, 9, 1, 8, 2, 7, 4, 6, 3, 10, 5, 11, 4 };
List<int> sortedList = BubbleSort( unsortedList );

Console.WriteLine( $"Unsorted list: {string.Join( ", ", unsortedList )}" );
// Unsorted list: 5, 9, 1, 8, 2, 7, 4, 6, 3, 10, 5, 11, 4

Console.WriteLine( $"Sorted list: {string.Join( ", ", sortedList )}" );
// Sorted list: 1, 2, 3, 4, 4, 5, 5, 6, 7, 8, 9, 10, 11
```