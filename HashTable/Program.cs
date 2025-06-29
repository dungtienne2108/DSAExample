namespace HashTable;

internal class Program
{
    static void Main(string[] args)
    {
        var dictionary = new MyHashTable();
        dictionary.Init();

        while (true)
        {
            Console.WriteLine("=== Bảng băm (Hash Table) ===");
            Console.WriteLine("1. Thêm cặp khóa-giá trị");
            Console.WriteLine("2. Tìm giá trị theo khóa");
            Console.WriteLine("3. Xóa cặp khóa-giá trị");
            Console.WriteLine("4. Hiển thị tất cả cặp khóa-giá trị");
            Console.WriteLine("5. Thoát");

            Console.WriteLine("Chọn một tùy chọn:");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Nhập khóa: ");
                    string key = Console.ReadLine();
                    Console.Write("Nhập giá trị: ");
                    string value = Console.ReadLine();
                    dictionary.Add(key, value);
                    break;
                case "2":
                    Console.Write("Nhập khóa cần tìm: ");
                    string searchKey = Console.ReadLine();
                    var foundValue = dictionary.Get(searchKey);
                    if (foundValue != null)
                        Console.WriteLine($"Giá trị của khóa '{searchKey}' là: {foundValue}");
                    else
                        Console.WriteLine($"Không tìm thấy khóa '{searchKey}'.");
                    break;
                case "3":
                    Console.Write("Nhập khóa cần xóa: ");
                    string removeKey = Console.ReadLine();
                    dictionary.Remove(removeKey);
                    Console.WriteLine($"Đã xóa khóa '{removeKey}'.");
                    break;
                case "4":
                    dictionary.Display();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Tùy chọn không hợp lệ. Vui lòng thử lại.");
                    break;
            }
        }

    }
}
