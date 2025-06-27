namespace LinkedList;

public class Node
{
    public Song Data { get; set; }
    public Node Next { get; set; }
    public Node(Song data)
    {
        Data = data;
        Next = null;
    }
}

public class MusicPlayList
{
    /// <summary>
    /// Node đầu tiên trong danh sách liên kết.
    /// </summary>
    private Node head;

    public MusicPlayList()
    {
        head = null;
    }

    /// <summary>
    /// Khởi tạo với một số bài hát mẫu.
    /// </summary>
    public void Init()
    {
        head = null;
        AddNewSong("Shape of You", "Ed Sheeran");
        AddNewSong("Blinding Lights", "The Weeknd");
        AddNewSong("Levitating", "Dua Lipa");
        AddNewSong("Bad Guy", "Billie Eilish");
        AddNewSong("Rolling in the Deep", "Adele");
        AddNewSong("Uptown Funk", "Mark Ronson ft. Bruno Mars");
        AddNewSong("Despacito", "Luis Fonsi ft. Daddy Yankee");
        AddNewSong("Someone Like You", "Adele");
    }

    /// <summary>
    /// Thêm một bài hát mới .
    /// </summary>
    /// <param name="title"></param>
    /// <param name="artist"></param>
    public void AddNewSong(string title, string artist)
    {
        Song song = new Song
        {
            Title = title,
            Artist = artist
        };

        Node newNode = new Node(song);

        if (head == null) // Nếu danh sách rỗng, đặt làm đầu
        {
            head = newNode;
        }
        else
        {
            Node current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }
    }

    /// <summary>
    /// Xóa một bài hát khỏi theo id.
    /// </summary>
    /// <param name="title"></param>
    public void RemoveSong(int id)
    {
        if (head == null) return;

        if (head.Data.Id == id) // nếu là node đầu, xóa luôn
        {
            head = head.Next;
            return;
        }

        // Chạy đến node trước node cần xóa
        Node current = head;
        while (current.Next != null && current.Next.Data.Id != id)
        {
            current = current.Next;
        }

        //  cập nhật
        if (current.Next != null)
        {
            current.Next = current.Next.Next;
        }
    }

    /// <summary>
    /// Tìm kiếm một bài hát theo id.
    /// </summary>
    /// <param name="title"></param>
    /// <returns></returns>
    public Song SearchSong(int id)
    {
        Node current = head;
        while (current != null)
        {
            if (current.Data.Id == id)
            {
                return current.Data;
            }
            current = current.Next;
        }
        return null;
    }

    /// <summary>
    /// Cập nhật thông tin của một bài hát theo id.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="title"></param>
    /// <param name="artist"></param>
    public void UpdateSong(int id, string title, string artist)
    {
        if (head == null) return;
        Node current = head;
        while (current != null)
        {
            if (current.Data.Id == id)
            {
                current.Data.Title = title;
                current.Data.Artist = artist;
                return;
            }
            current = current.Next;
        }
    }

    /// <summary>
    /// Hiển thị tất cả các bài hát.
    /// </summary>
    public void Display()
    {
        Node current = head;
        Console.WriteLine("--- Music Playlist ---");
        while (current != null)
        {
            Console.WriteLine($"Id: {current.Data.Id}, Title: {current.Data.Title}, Artist: {current.Data.Artist}");
            current = current.Next;
        }
    }
}
