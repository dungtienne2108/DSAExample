namespace LinkedList;

/// <summary>
/// Biểu diễn một bài hát chỉ có tiêu đề và nghệ sĩ. 
/// </summary>
public class Song
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Artist { get; set; }

    private static int _nextId = 1;
    public Song()
    {
        Id = _nextId++;
    }
}
