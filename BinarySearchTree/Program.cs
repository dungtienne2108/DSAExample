namespace BinarySearchTree;

internal class Program
{
    static void Main(string[] args)
    {
        BinarySearchTree bst = new BinarySearchTree();
        bst.Init();

        while (true)
        {
            Console.WriteLine("==== Cây Nhị Phân Tìm Kiếm (Binary Search Tree) ====");
            Console.WriteLine("1. Thêm giá trị vào cây");
            Console.WriteLine("2. Tìm kiếm giá trị trong cây");
            Console.WriteLine("3. Xóa giá trị trong cây");
            Console.WriteLine("4. Hiển thị cây (In-order)");
            Console.WriteLine("5. Hiển thị cây (Pre-order)");
            Console.WriteLine("6. Hiển thị cây (Post-order)");
            Console.WriteLine("7. Thoát");

            Console.Write("Chọn một tùy chọn: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Write("Nhập giá trị cần thêm: ");
                    if (int.TryParse(Console.ReadLine(), out int valueToAdd))
                    {
                        bst.Insert(valueToAdd);
                        Console.WriteLine($"Đã thêm giá trị {valueToAdd} vào cây.");
                    }
                    else
                    {
                        Console.WriteLine("Giá trị không hợp lệ. Vui lòng nhập một số nguyên.");
                    }
                    break;
                case "2":
                    Console.Write("Nhập giá trị cần tìm: ");
                    if (int.TryParse(Console.ReadLine(), out int valueToSearch))
                    {
                        bool found = bst.Search(valueToSearch);
                        if (found)
                        {
                            Console.WriteLine($"Giá trị {valueToSearch} đã được tìm thấy trong cây.");
                        }
                        else
                        {
                            Console.WriteLine($"Giá trị {valueToSearch} không có trong cây.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Giá trị không hợp lệ. Vui lòng nhập một số nguyên.");
                    }
                    break;
                case "3":
                    Console.Write("Nhập giá trị cần xóa: ");
                    if (int.TryParse(Console.ReadLine(), out int valueToRemove))
                    {
                        bst.Delete(valueToRemove);
                        Console.WriteLine($"Đã xóa giá trị {valueToRemove} khỏi cây.");
                    }
                    else
                    {
                        Console.WriteLine("Giá trị không hợp lệ. Vui lòng nhập một số nguyên.");
                    }
                    break;
                case "4":
                    bst.InOrderTraversal();
                    break;
                case "5":
                    bst.PreOrderTraversal();
                    break;
                case "6":
                    bst.PostOrderTraversal();
                    break;
                case "7":
                    Console.WriteLine("Thoát chương trình.");
                    return;
                default:
                    Console.WriteLine("Tùy chọn không hợp lệ. Vui lòng chọn lại.");
                    break;
            }
        }
    }
}
