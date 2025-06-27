namespace LinkedList;

internal class Program
{
    static void Main(string[] args)
    {
        MusicPlayList playlist = new MusicPlayList();
        playlist.Init();

        while (true)
        {
            Console.WriteLine("\n--- Music Playlist Menu ---");
            Console.WriteLine("1. Add Song");
            Console.WriteLine("2. Display Playlist");
            Console.WriteLine("3. Search Song");
            Console.WriteLine("4. Remove Song");
            Console.WriteLine("5. Update Song");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Nhập tiêu đề bài hát: ");
                    string title = Console.ReadLine();
                    Console.Write("Nhập tên tác giả: ");
                    string artist = Console.ReadLine();
                    playlist.AddNewSong(title, artist);
                    break;
                case "2":
                    playlist.Display();
                    break;
                case "3":
                    Console.Write("Nhập id bài hát: ");
                    if (int.TryParse(Console.ReadLine(), out int searchId))
                    {
                        var song = playlist.SearchSong(searchId);
                        if (song != null)
                        {
                            Console.WriteLine($"Đã tìm thấy - Id: {song.Id}, Title: {song.Title}, Artist: {song.Artist}");
                        }
                        else
                        {
                            Console.WriteLine("Bài hát không tồn tại.");
                        }
                    }
                    break;
                case "4":
                    Console.Write("NHập id bài hát muốn xóa: ");
                    if (int.TryParse(Console.ReadLine(), out int removeId))
                    {
                        playlist.RemoveSong(removeId);
                        Console.WriteLine($"Xóa bài hát với id {removeId} thành công.");
                    }
                    break;
                case "5":
                    Console.Write("Nhập id bài hát muốn cập nhật: ");
                    if (int.TryParse(Console.ReadLine(), out int updateId))
                    {
                        Console.Write("Nhập tiêu đề mới: ");
                        string newTitle = Console.ReadLine();
                        Console.Write("Nhập tên tác giả mới: ");
                        string newArtist = Console.ReadLine();
                        playlist.UpdateSong(updateId, newTitle, newArtist);
                        Console.WriteLine($"Cập nhật bài hát với id {updateId} thành công.");
                    }
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Không hợp lệ, vui lòng thử lại.");
                    break;
            }
        }

    }
}
