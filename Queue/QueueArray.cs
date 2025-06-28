namespace Queue;

public class QueueArray
{
    private string[] _items;
    private int _front; // Đầu
    private int _rear; // cuối
    private int _count; // số lượng hiện tại
    private int _size; // kích thước

    public QueueArray(int size)
    {
        _size = size;
        _items = new string[_size];
        _front = 0;
        _rear = -1;
        _count = 0;
    }

    public void Init()
    {
        _front = 0;
        _rear = -1;
        _count = 0;
        Enqueue("Khách hàng 1");
        Enqueue("Khách hàng 2");
        Enqueue("Khách hàng 3");
        Enqueue("Khách hàng 4");
        Enqueue("Khách hàng 5");
    }

    public bool IsEmpty() => _count == 0;
    public bool IsFull() => _count == _size;
    public int Count() => _count;

    /// <summary>
    /// Thêm một phần tử vào cuối hàng đợi
    /// </summary>
    /// <param name="item"></param>
    public void Enqueue(string item)
    {
        if (IsFull())
        {
            Console.WriteLine("Hàng đợi đã đầy");
            return;
        }
        _rear = (_rear + 1) % _size;  // quay lại nếu đến cuối mảng
        _items[_rear] = item;
        _count++;
    }

    /// <summary>
    /// Lấy phần tử đầu tiên khỏi hàng đợi
    /// </summary>
    /// <returns></returns>
    public string Dequeue()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Hàng đợi rỗng");
            return null;
        }
        string item = _items[_front];
        _items[_front] = null; // Xóa phần tử đã lấy
        _front = (_front + 1) % _size; // quay lại nếu đến cuối mảng
        _count--;
        return item;
    }

    /// <summary>
    /// Lấy phần tử đầu tiên mà không xóa nó khỏi hàng đợi
    /// </summary>
    /// <returns></returns>
    public string Peek()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Hàng đợi rỗng");
            return null;
        }
        return _items[_front];
    }

    /// <summary>
    /// Hiển thị nội dung của hàng đợi
    /// </summary>
    public void Display()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Hàng đợi rỗng");
            return;
        }
        Console.Write("Hàng đợi: ");
        for (int i = 0; i < _count; i++)
        {
            int index = (_front + i) % _size;
            Console.Write(_items[index] + " | ");
        }
        Console.WriteLine();
    }
}
