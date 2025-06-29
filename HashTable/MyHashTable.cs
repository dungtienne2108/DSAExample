namespace HashTable;

public class Node
{
    public string Key { get; set; }
    public string Value { get; set; }
    public Node Next { get; set; }

    public Node(string key, string value)
    {
        Key = key;
        Value = value;
        Next = null;
    }
}

public class MyHashTable
{
    private readonly int _size;
    private readonly LinkedList<Node>[] _buckets; // LinkedList có sẵn trong C#

    /// <summary>
    /// Khởi tạo với size.
    /// </summary>
    /// <param name="size"></param>
    public MyHashTable(int size = 101) // Size là số nguyên tố để giảm va chạm
    {
        _size = size;
        _buckets = new LinkedList<Node>[size];
        for (int i = 0; i < size; i++)
        {
            _buckets[i] = new LinkedList<Node>();
        }
    }

    public void Init()
    {
        Add("name", "John Doe");
        Add("age", "30");
        Add("city", "New York");
        Add("country", "USA");
        Add("occupation", "Software Engineer");
        Add("hobby", "Reading");
        Add("language", "C#");
        Add("framework", "ASP.NET Core");
        Add("company", "Tech Company");
        Add("project", "HashTable Implementation");
    }

    /// <summary>
    /// Tính toán hàm băm cho khóa
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    private int GetHash(string key)
    {
        int hash = 0;
        foreach (char c in key)
        {
            hash += c; // tính tổng giá trị ascii
        }
        return Math.Abs(hash) % _buckets.Length;
    }

    /// <summary>
    /// Lấy chỉ số của bucket dựa trên khóa
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    private int GetIndex(string key)
    {
        int hash = GetHash(key);
        return Math.Abs(hash % _size);
    }

    /// <summary>
    /// Thêm một cặp khóa-giá trị vào bảng băm
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    public void Add(string key, string value)
    {
        int index = GetIndex(key);
        Node newNode = new Node(key, value);

        // khóa tồn tại chưa
        foreach (var node in _buckets[index])
        {
            if (node.Key == key)
            {
                node.Value = value; // update nếu khóa đã tồn tại
                return;
            }
        }

        // THêm vào đầu
        _buckets[index].AddFirst(newNode);
    }

    /// <summary>
    /// Lấy giá trị theo khóa
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public string Get(string key)
    {
        int index = GetIndex(key);
        foreach (var node in _buckets[index])
        {
            if (node.Key == key)
            {
                return node.Value;
            }
        }
        return null; // không thấy khóa
    }

    /// <summary>
    /// Xóa một cặp khóa-giá trị khỏi bảng băm
    /// </summary>
    /// <param name="key"></param>
    public void Remove(string key)
    {
        int index = GetIndex(key);
        Node previousNode = null;
        foreach (var node in _buckets[index])
        {
            if (node.Key == key)
            {
                if (previousNode == null)
                {
                    _buckets[index].RemoveFirst(); // Xóa node đầu tiên
                }
                else
                {
                    _buckets[index].Remove(node); // Xóa node giữa hoặc cuối
                }
                return;
            }
            previousNode = node;
        }
    }

    /// <summary>
    /// Kiểm tra xem bảng băm có chứa khóa hay không
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public bool ContainsKey(string key)
    {
        int index = GetIndex(key);
        foreach (var node in _buckets[index])
        {
            if (node.Key == key)
            {
                return true;
            }
        }
        return false; // không tìm thấy khóa
    }

    public void Display()
    {
        for (int i = 0; i < _buckets.Length; i++)
        {
            if (_buckets[i].Count > 0)
            {
                foreach (var node in _buckets[i])
                {
                    Console.WriteLine($"Ô thứ {i}: Key: {node.Key}, Value: {node.Value}");
                }
            }
        }
    }
}
