namespace Sort;

internal class Program
{
    static void Main(string[] args)
    {
        int[] data = { 9, 3, 5, 1, 7 };

        Console.WriteLine("Trước khi sắp xếp : ");
        for (int i = 0; i < data.Length; i++)
        {
            Console.Write(data[i] + " ");
        }

        AllSorts.BubbleSort(data);
        // AllSorts.SelectionSort(data);
        // AllSorts.InsertionSort(data);
        // AllSorts.MergeSort(data);
        // AllSorts.QuickSort(data);
        // AllSorts.HeapSort(data);

        Console.WriteLine();
        Console.WriteLine("Sau khi sắp xếp : ");
        for (int i = 0; i < data.Length; i++)
        {
            Console.Write(data[i] + " ");
        }
    }
}
