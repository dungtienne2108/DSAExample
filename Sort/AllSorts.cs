namespace Sort;

public static class AllSorts
{
    /// <summary>
    /// Hoán vị hai phần tử trong mảng
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="i"></param>
    /// <param name="j"></param>
    private static void Swap(int[] arr, int i, int j)
    {
        if (i == j) return;
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }

    /// <summary>
    /// Bubble Sort
    /// </summary>
    /// <param name="arr"></param>
    public static void BubbleSort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
            for (int j = 0; j < n - i - 1; j++)
                if (arr[j] > arr[j + 1])
                    Swap(arr, j, j + 1);
    }

    /// <summary>
    /// Selection Sort
    /// </summary>
    /// <param name="arr"></param>
    public static void SelectionSort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            int min = i;
            for (int j = i + 1; j < n; j++)
                if (arr[j] < arr[min])
                    min = j;
            Swap(arr, i, min);
        }
    }

    /// <summary>
    /// Insertion Sort
    /// </summary>
    /// <param name="arr"></param>
    public static void InsertionSort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 1; i < n; i++)
        {
            int key = arr[i];
            int j = i - 1;
            while (j >= 0 && arr[j] > key)
                arr[j + 1] = arr[j--];
            arr[j + 1] = key;
        }
    }

    /// <summary>
    /// Merge Sort
    /// </summary>
    /// <param name="arr"></param>
    public static void MergeSort(int[] arr)
    {
        if (arr.Length <= 1) return;
        MergeSort(arr, 0, arr.Length - 1);
    }

    /// <summary>
    /// Hàm đệ quy thực hiện sắp xếp trộn
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="left"></param>
    /// <param name="right"></param>
    private static void MergeSort(int[] arr, int left, int right)
    {
        if (left >= right) return;
        int mid = (left + right) / 2;
        MergeSort(arr, left, mid);
        MergeSort(arr, mid + 1, right);
        Merge(arr, left, mid, right);
    }

    /// <summary>
    /// Hàm trộn hai mảng đã sắp xếp
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="left"></param>
    /// <param name="mid"></param>
    /// <param name="right"></param>
    private static void Merge(int[] arr, int left, int mid, int right)
    {
        int[] temp = new int[right - left + 1];
        int i = left, j = mid + 1, k = 0;
        while (i <= mid && j <= right)
            temp[k++] = (arr[i] <= arr[j]) ? arr[i++] : arr[j++];
        while (i <= mid) temp[k++] = arr[i++];
        while (j <= right) temp[k++] = arr[j++];
        for (i = left; i <= right; i++)
            arr[i] = temp[i - left];
    }

    /// <summary>
    /// Quick Sort
    /// </summary>
    /// <param name="arr"></param>
    public static void QuickSort(int[] arr)
    {
        QuickSort(arr, 0, arr.Length - 1);
    }

    /// <summary>
    /// Hàm đệ quy thực hiện sắp xếp nhanh
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="low"></param>
    /// <param name="high"></param>
    private static void QuickSort(int[] arr, int low, int high)
    {
        if (low >= high) return;
        int pi = Partition(arr, low, high);
        QuickSort(arr, low, pi - 1);
        QuickSort(arr, pi + 1, high);
    }

    /// <summary>
    /// Hàm phân vùng cho Quick Sort
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="low"></param>
    /// <param name="high"></param>
    /// <returns></returns>
    private static int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high];
        int i = low - 1;
        for (int j = low; j < high; j++)
            if (arr[j] < pivot)
                Swap(arr, ++i, j);
        Swap(arr, i + 1, high);
        return i + 1;
    }

    /// <summary>
    /// Heap Sort
    /// </summary>
    /// <param name="arr"></param>
    public static void HeapSort(int[] arr)
    {
        int n = arr.Length;
        for (int i = n / 2 - 1; i >= 0; i--)
            Heapify(arr, n, i);
        for (int i = n - 1; i > 0; i--)
        {
            Swap(arr, 0, i);
            Heapify(arr, i, 0);
        }
    }

    /// <summary>
    /// Hàm Heapify cho Heap Sort
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="n"></param>
    /// <param name="i"></param>
    private static void Heapify(int[] arr, int n, int i)
    {
        int largest = i, l = 2 * i + 1, r = 2 * i + 2;
        if (l < n && arr[l] > arr[largest]) largest = l;
        if (r < n && arr[r] > arr[largest]) largest = r;
        if (largest != i)
        {
            Swap(arr, i, largest);
            Heapify(arr, n, largest);
        }
    }
}
