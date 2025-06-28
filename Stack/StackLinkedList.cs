namespace Stack;

public class Node
{
    public char Data { get; set; }
    public Node Next { get; set; }
    public Node(char data)
    {
        Data = data;
        Next = null;
    }
}

public class StackLinkedList
{
    private Node _top;
    private int _size;

    public StackLinkedList()
    {
        _top = null;
        _size = 0;
    }

    /// <summary>
    /// Đẩy một ký tự vào ngăn xếp
    /// </summary>
    /// <param name="item"></param>
    public void Push(char item)
    {
        Node newNode = new Node(item);
        newNode.Next = _top; // Đặt nút mới lên đầu ngăn xếp
        _top = newNode;
        _size++;
    }

    /// <summary>
    /// Lấy ký tự ở đỉnh ngăn xếp và loại bỏ nó khỏi ngăn xếp
    /// </summary>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public char Pop()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Ngăn xếp rỗng");
        }
        char item = _top.Data;
        _top = _top.Next; //
        _size--;
        return item;
    }

    /// <summary>
    /// Lấy ký tự ở đỉnh ngăn xếp mà không loại bỏ nó
    /// </summary>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public char Peek()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Ngăn xếp rỗng");
        }
        return _top.Data;
    }

    public bool IsEmpty() => _top == null;
    public int Size() => _size;
}
