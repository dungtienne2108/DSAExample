namespace BinarySearchTree;

public class Node
{
    public int Value { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }
    public Node(int value)
    {
        Value = value;
        Left = null;
        Right = null;
    }
}

public class BinarySearchTree
{
    private Node _root;
    public BinarySearchTree()
    {
        _root = null;
    }

    /// <summary>
    /// Khởi tạo cây nhị phân tìm kiếm với một số giá trị.
    /// </summary>
    public void Init()
    {
        Insert(90);
        Insert(50);
        Insert(30);
        Insert(20);
        Insert(40);
        Insert(70);
        Insert(60);
        Insert(80);
    }

    /// <summary>
    /// Thêm mới một giá trị vào cây nhị phân tìm kiếm.
    /// </summary>
    /// <param name="value"></param>
    public void Insert(int value)
    {
        _root = InsertRec(_root, value);
    }

    /// <summary>
    /// Thêm mới một giá trị vào cây nhị phân tìm kiếm.
    /// </summary>
    /// <param name="root"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    private Node InsertRec(Node root, int value)
    {
        if (root == null)
        {
            return new Node(value);
        }
        if (value < root.Value) // Nếu giá trị nhỏ hơn nút hiện tại, thêm trái
        {
            root.Left = InsertRec(root.Left, value);
        }
        else if (value > root.Value) // Nếu giá trị lớn hơn nút hiện tại, thêm phải
        {
            root.Right = InsertRec(root.Right, value);
        }
        return root;
    }

    /// <summary>
    /// Tìm kiếm một giá trị trong cây nhị phân tìm kiếm.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public bool Search(int value)
    {
        return SearchRec(_root, value);
    }

    /// <summary>
    /// Tìm kiếm một giá trị trong cây nhị phân tìm kiếm.
    /// </summary>
    /// <param name="root"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    private bool SearchRec(Node root, int value)
    {
        if (root == null)
        {
            return false;
        }

        if (root.Value == value)
        {
            return true;
        }

        if (value < root.Value) // Nếu bé hơn nút hiện tại, tìm trái
        {
            return SearchRec(root.Left, value);
        }
        else // Nếu lớn hơn nút hiện tại, tìm phải
        {
            return SearchRec(root.Right, value);
        }
    }

    /// <summary>
    /// Xóa một giá trị khỏi cây nhị phân tìm kiếm.
    /// </summary>
    /// <param name="value"></param>
    public void Delete(int value)
    {
        _root = DeleteRec(_root, value);
    }

    /// <summary>
    /// Xóa một giá trị khỏi cây nhị phân tìm kiếm.
    /// </summary>
    /// <param name="root"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    private Node DeleteRec(Node root, int value)
    {
        if (root == null)
        {
            return root;
        }
        if (value < root.Value) // Nếu giá trị nhỏ hơn nút hiện tại, sang trái
        {
            root.Left = DeleteRec(root.Left, value);
        }
        else if (value > root.Value) // Nếu giá trị lớn hơn nút hiện tại, sang trái
        {
            root.Right = DeleteRec(root.Right, value);
        }
        else // Nút cần xóa được tìm thấy
        {
            // Nút có một con hoặc không có con
            if (root.Left == null)
            {
                return root.Right;
            }
            else if (root.Right == null)
            {
                return root.Left;
            }
            // Nút có hai con: Tìm giá trị nhỏ nhất bên phải
            Node minNode = FindMin(root.Right);
            root.Value = minNode.Value; // gán giá trị của nút hiện tại bằng giá trị nhỏ nhất
            root.Right = DeleteRec(root.Right, minNode.Value); // Xóa nút nhỏ nhất
        }
        return root;
    }

    /// <summary>
    /// Tìm nút có giá trị nhỏ nhất trong cây nhị phân tìm kiếm.
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    private Node FindMin(Node root)
    {
        while (root.Left != null)
        {
            root = root.Left;
        }
        return root;
    }

    /// <summary>
    /// Duyệt cây theo thứ tự InOrder (trái - gốc - phải).
    /// </summary>
    public void InOrderTraversal()
    {
        Console.Write("InOrder: ");
        InOrderRec(_root);
        Console.WriteLine();
    }

    /// <summary>
    /// Duyệt cây theo thứ tự InOrder (trái - gốc - phải). 
    /// </summary>
    /// <param name="root"></param>
    private void InOrderRec(Node root)
    {
        if (root != null)
        {
            InOrderRec(root.Left); // sang trái
            Console.Write(root.Value + " ");
            InOrderRec(root.Right); // sang phải
        }
    }

    /// <summary>
    /// Duyệt cây theo thứ tự PreOrder (gốc - trái - phải).
    /// </summary>
    public void PreOrderTraversal()
    {
        Console.Write("PreOrder: ");
        PreOrderRec(_root);
        Console.WriteLine();
    }

    /// <summary>
    /// Duyệt cây theo thứ tự PreOrder (gốc - trái - phải).
    /// </summary>
    /// <param name="root"></param>
    private void PreOrderRec(Node root)
    {
        if (root != null)
        {
            Console.Write(root.Value + " ");
            PreOrderRec(root.Left); // sang trái
            PreOrderRec(root.Right); // sang phải
        }
    }

    /// <summary>
    /// Duyệt cây theo thứ tự PostOrder (trái - phải - gốc).
    /// </summary>
    public void PostOrderTraversal()
    {
        Console.Write("PostOrder: ");
        PostOrderRec(_root);
        Console.WriteLine();
    }

    /// <summary>
    /// Duyệt cây theo thứ tự PostOrder (trái - phải - gốc).
    /// </summary>
    /// <param name="root"></param>
    private void PostOrderRec(Node root)
    {
        if (root != null)
        {
            PostOrderRec(root.Left); // sang trái
            PostOrderRec(root.Right); // sang phải
            Console.Write(root.Value + " ");
        }
    }
}
