namespace Recursion
{
    internal class Program
    {
        /// <summary>
        /// Tìm số fibonacci thứ n.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static long Fibonacci(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;

            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        static void Main(string[] args)
        {
            Console.Write("Nhập n: ");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine($"Fibonacci thứ {n} là: {Fibonacci(n)}");
        }
    }
}
