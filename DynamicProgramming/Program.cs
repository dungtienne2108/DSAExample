namespace DynamicProgramming
{
    internal class Program
    {
        // Bottom-Up
        public static int ClimbStairsBottomUp(int n)
        {
            if (n == 0 || n == 1) // trường hợp cơ sở : Nếu có 0 hoặc 1 bậc
                return 1;

            int[] dp = new int[n + 1]; // số cách leo
            dp[0] = 1; // 1 cách leo 0 bậc
            dp[1] = 1;// 1 cách leo 1 bậc

            // số cách leo từ 2 bậc trở lên
            for (int i = 2; i <= n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }

            return dp[n];
        }

        // lưu kết quả đã tính
        private static Dictionary<int, int> memo = new Dictionary<int, int>();

        // Top-Down
        public static int ClimbStairsTopDown(int n)
        {
            // trường hợp cơ sở
            if (n == 0 || n == 1)
                return 1;

            if (memo.ContainsKey(n)) // nếu đã tính rồi thì trả về kết quả đã lưu
                return memo[n];

            // tính số cách leo từ bậc n - 1 và n - 2 đến n
            memo[n] = ClimbStairsTopDown(n - 1) + ClimbStairsTopDown(n - 2);
            return memo[n];
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Bottom-Up:");
            Console.WriteLine(ClimbStairsBottomUp(4));

            Console.WriteLine("Top-Down:");
            Console.WriteLine(ClimbStairsTopDown(4));

        }
    }
}
