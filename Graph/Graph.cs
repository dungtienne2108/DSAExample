namespace Graphs;

public class Graph
{
    private int V; // Số đỉnh
    private List<int>[] adj; // danh sách kề : Mảng các list

    public Graph(int v)
    {
        V = v;
        adj = new List<int>[v];
        for (int i = 0; i < v; i++)
        {
            adj[i] = new List<int>();
        }
    }

    public void Init()
    {
        AddEdge(0, 1);
        AddEdge(0, 2);
        AddEdge(1, 2);
        AddEdge(1, 3);
        AddEdge(2, 4);
        AddEdge(3, 4);
        AddEdge(4, 5);
        AddEdge(5, 6);
        AddEdge(6, 7);
        AddEdge(7, 8);
    }

    /// <summary>
    /// Thêm cạnh vào đồ thị vô hướng
    /// </summary>
    /// <param name="v"></param>
    /// <param name="w"></param>
    public void AddEdge(int v, int w)
    {
        adj[v].Add(w); // Thêm cạnh từ v đến w
        adj[w].Add(v); // Thêm cạnh từ w đến v 
    }

    private void DFSUtil(int v, bool[] visited)
    {
        // v đã thăm
        visited[v] = true;
        Console.Write(v + " ");
        //các đỉnh kề với v
        foreach (int neighbor in adj[v])
        {
            if (!visited[neighbor]) // chưa thăm
            {
                DFSUtil(neighbor, visited);
            }
        }
    }

    /// <summary>
    /// Duyệt theo chiều sâu (Depth First Search - DFS)
    /// </summary>
    /// <param name="start"></param>
    public void DFS(int start)
    {
        bool[] visited = new bool[V]; // Các đỉnh đã thăm
        Console.WriteLine($"DFS bắt đầu từ {start}");
        DFSUtil(start, visited);
        Console.WriteLine();
    }

    /// <summary>
    /// Duyệt theo chiều rộng (Breadth First Search - BFS)
    /// </summary>
    /// <param name="start"></param>
    public void BFS(int start)
    {
        bool[] visited = new bool[V];
        Queue<int> queue = new Queue<int>();

        visited[start] = true;
        queue.Enqueue(start);

        Console.WriteLine($"BFS bắt đầu từ {start}");
        while (queue.Count > 0)
        {
            int v = queue.Dequeue();
            Console.Write(v + " ");
            foreach (int neighbor in adj[v])
            {
                if (!visited[neighbor])
                {
                    visited[neighbor] = true;
                    queue.Enqueue(neighbor);
                }
            }
        }
        Console.WriteLine();
    }
}
