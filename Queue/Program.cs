namespace Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Chọn cấu trúc dữ liệu cho hàng đợi:");
            Console.WriteLine("1. Mảng");
            Console.WriteLine("2. Linked List");
            Console.Write("Lựa chọn: ");

            string choice = Console.ReadLine();
            dynamic queue = null;
            switch (choice)
            {
                case "1":
                    queue = new QueueArray(5);
                    queue.Init();
                    break;
                case "2":
                    queue = new QueueLinkedList();
                    queue.Init();
                    break;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ.");
                    return;
            }

            while (true)
            {
                Console.WriteLine("\nHệ Thống Xếp Hàng Cửa Hàng Tiện Lợi");
                Console.WriteLine("1. Khách hàng đến");
                Console.WriteLine("2. Phục vụ khách hàng");
                Console.WriteLine("3. Kiểm tra hàng đợi");
                Console.WriteLine("4. Kiểm tra số lượng");
                Console.WriteLine("5. Thoát");
                Console.Write("Chọn một tùy chọn: ");

                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        Console.Write("Nhập tên khách hàng: ");
                        string customerName = Console.ReadLine();
                        queue.Enqueue(customerName);
                        Console.WriteLine($"Khách hàng {customerName} đã được thêm vào hàng đợi.");
                        break;
                    case "2":
                        string servedCustomer = queue.Dequeue();
                        if (servedCustomer != null)
                        {
                            Console.WriteLine($"Đã phục vụ khách hàng: {servedCustomer}");
                        }
                        break;
                    case "3":
                        queue.Display();
                        break;
                    case "4":
                        Console.WriteLine($"Số lượng khách hàng trong hàng đợi: {queue.Count()}");
                        break;
                    case "5":
                        Console.WriteLine("Thoát chương trình.");
                        return;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng thử lại.");
                        break;
                }
            }

        }
    }
}
