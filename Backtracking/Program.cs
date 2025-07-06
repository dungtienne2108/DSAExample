namespace Backtracking;

internal class Program
{
    /// <summary>
    /// Tìm tất cả các tập con của mảng.
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="n"></param>
    /// <param name="index"></param>
    /// <param name="subset"></param>
    /// <param name="subsetSize"></param>
    public static void GenerateSubsets(int[] arr, int n, int index, int[] subset, int subsetSize)
    {
        if (index == n)
        {
            Console.Write("{ ");
            for (int i = 0; i < subsetSize; i++) // In các phần tử của tập con
            {
                Console.Write(subset[i]);
                if (i < subsetSize - 1) Console.Write(", ");
            }
            Console.WriteLine(" }");
            return;
        }

        GenerateSubsets(arr, n, index + 1, subset, subsetSize); // quay lại, không chọn tại index

        subset[subsetSize] = arr[index]; // thêm vào tập con
        GenerateSubsets(arr, n, index + 1, subset, subsetSize + 1); // quay lại, chọn tại index
    }
    static void Main(string[] args)
    {
        int[] arr = { 1, 2, 3 };
        int n = arr.Length;

        int[] subset = new int[n]; // lưu các phần tử của tập con (tạm thời)

        Console.WriteLine("Các tập con của tập {1, 2, 3}:");
        GenerateSubsets(arr, n, 0, subset, 0);
    }
}
