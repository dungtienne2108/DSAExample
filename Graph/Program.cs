namespace Graphs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Graph g = new Graph(9);
            g.Init();

            g.BFS(0);
            g.DFS(0);
        }
    }
}
