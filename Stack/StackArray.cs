namespace Stack;

public class StackArray
{
    private char[] _array;
    private int _top; // Vị trí đỉnh của ngăn xếp
    private int _size; // Kích thước của ngăn xếp

    public StackArray(int size)
    {
        _array = new char[size];
        _top = -1; // Khởi tạo ngăn xếp rỗng
        _size = size;
    }

    /// <summary>
    /// Đẩy một ký tự vào ngăn xếp
    /// </summary>
    /// <param name="item"></param>
    /// <exception cref="InvalidOperationException"></exception>
    public void Push(char item)
    {
        if (_top >= _size - 1)
        {
            throw new InvalidOperationException("Ngăn xếp đầy");
        }
        _array[++_top] = item;
    }

    /// <summary>
    /// Lấy ký tự ở đỉnh ngăn xếp và loại bỏ nó khỏi ngăn xếp
    /// </summary>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public char Pop()
    {
        if (_top < 0)
        {
            throw new InvalidOperationException("Ngăn xếp rỗng");
        }
        return _array[_top--];
    }

    /// <summary>
    /// Lấy ký tự ở đỉnh ngăn xếp mà không loại bỏ nó
    /// </summary>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public char Peek()
    {
        if (_top < 0)
        {
            throw new InvalidOperationException("Ngăn xếp rỗng");
        }
        return _array[_top];
    }

    public bool IsEmpty() => _top < 0;

    public int Size() => _top + 1;
}
