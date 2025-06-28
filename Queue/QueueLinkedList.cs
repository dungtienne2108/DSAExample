namespace Queue;

public class Node
{
    public string Data { get; set; }
    public Node Next { get; set; }
    public Node(string data)
    {
        Data = data;
        Next = null;
    }
}

public class QueueLinkedList
{
    private Node _front; // đầu
    private Node _rear;// cuối
    private int _count; // số lượng hiện tại

    public QueueLinkedList()
    {
        _front = null;
        _rear = null;
        _count = 0;
    }

    public void Init()
    {
        Enqueue("Khách hàng 1");
        Enqueue("Khách hàng 2");
        Enqueue("Khách hàng 3");
        Enqueue("Khách hàng 4");
        Enqueue("Khách hàng 5");
    }
    public bool IsEmpty() => _count == 0;
    public int Count() => _count;
    /// <summary>
    /// Thêm một phần tử vào cuối hàng đợi
    /// </summary>
    /// <param name="item"></param>
    public void Enqueue(string item)
    {
        Node newNode = new Node(item);
        if (IsEmpty())
        {
            _front = newNode; // nếu hàng đợi rỗng, đặt front là node mới
            _rear = newNode; // và rear cũng là node mới
        }
        else
        {
            _rear.Next = newNode; // nối node mới vào cuối hàng đợi
            _rear = newNode; // cập nhật rear
        }
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
        string item = _front.Data;
        _front = _front.Next; // di chuyển đầu hàng đợi
        _count--;
        if (IsEmpty())
            _rear = null; // nếu hàng đợi rỗng, đặt rear là null
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
        return _front.Data;
    }
    /// <summary>
    /// Hiển thị tất cả các phần tử trong hàng đợi
    /// </summary>
    public void Display()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Hàng đợi rỗng");
            return;
        }
        Node current = _front;
        Console.Write("Hàng đợi: ");
        while (current != null)
        {
            Console.Write(current.Data + " | ");
            current = current.Next;
        }
        Console.WriteLine();
    }
}
