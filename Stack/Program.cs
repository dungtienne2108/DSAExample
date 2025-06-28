namespace Stack
{
    internal class Program
    {
        /// <summary>
        /// Kiểm tra với mảng
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool CheckWithArray(string input)
        {
            var stack = new StackArray(input.Length);

            foreach (char c in input)
            {
                if (c == '(' || c == '{' || c == '[')
                    stack.Push(c); // đẩy ký tự mở vào ngăn xếp
                else if (c == ')' || c == '}' || c == ']') // kiểm tra ký tự đóng
                {
                    if (stack.IsEmpty())
                        return false;

                    char top = stack.Pop();
                    if ((c == ')' && top != '(') ||
                        (c == '}' && top != '{') ||
                        (c == ']' && top != '['))
                    {
                        return false;
                    }
                }
            }
            return stack.IsEmpty();
        }

        public static bool CheckWithLinkedList(string input)
        {
            var stack = new StackLinkedList();
            foreach (char c in input)
            {
                if (c == '(' || c == '{' || c == '[')
                    stack.Push(c); // đẩy ký tự mở vào ngăn xếp
                else if (c == ')' || c == '}' || c == ']') // kiểm tra ký tự đóng
                {
                    if (stack.IsEmpty())
                        return false;
                    char top = stack.Pop();
                    if ((c == ')' && top != '(') ||
                        (c == '}' && top != '{') ||
                        (c == ']' && top != '['))
                    {
                        return false;
                    }
                }
            }
            return stack.IsEmpty();
        }

        static void Main(string[] args)
        {
            string input = "{[()]()}";
            // Chuỗi không hợp lệ : // string input = "{[(])}";

            Console.WriteLine($"Chuỗi cần kiểm tra :{input} ");

            Console.WriteLine("Kiểm tra bằng mảng : ");
            bool isValidArray = CheckWithArray(input);
            Console.WriteLine(isValidArray ? "Chuỗi hợp lệ" : "Chuỗi không hợp lệ");

            Console.WriteLine("Kiểm tra bằng danh sách liên kết : ");
            bool isValidLinkedList = CheckWithLinkedList(input);
            Console.WriteLine(isValidLinkedList ? "Chuỗi hợp lệ" : "Chuỗi không hợp lệ");
        }
    }
}
