using System.Text;
using MusicPlaylistManager;

public class Playlist
{
    public string Name { get; set; }
    private SongNode? head; 

    public Playlist(string name)
    {
        Name = name;
        head = null;
    }

    public void ExportToCSV(string filePath)
    {
        if (head == null)
        {
            Console.WriteLine("Playlist is empty. No songs to export.");
            return;
        }

        StringBuilder csvContent = new StringBuilder();
        csvContent.AppendLine(Name); 
        csvContent.AppendLine("Title,Artist,Genre,Decade,Duration"); 

        SongNode temp = head;
        while (temp != null)
        {
            csvContent.AppendLine($"{temp.Data.Title},{temp.Data.Artist},{temp.Data.Genre},{temp.Data.Decade},{temp.Data.Duration}");
            temp = temp.Next;
        }

        File.WriteAllText(filePath, csvContent.ToString());
        Console.WriteLine($"Playlist '{Name}' exported to {filePath}");
    }


    public static Playlist LoadFromCSV(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("No previous playlist found.");
            return null;
        }

        string[] lines = File.ReadAllLines(filePath);
        if (lines.Length < 2) 
        {
            Console.WriteLine("Playlist file is empty.");
            return null;
        }

        string playlistName = lines[0]; 
        Playlist loadedPlaylist = new Playlist(playlistName);

        for (int i = 2; i < lines.Length; i++) 
        {
            string[] data = lines[i].Split(',');

            if (data.Length == 5)
            {
                string title = data[0];
                string artist = data[1];
                string genre = data[2];
                int decade = int.Parse(data[3]);
                double duration = double.Parse(data[4]);

                Song newSong = new Song(title, artist, genre, decade, duration);
                loadedPlaylist.AddSong(newSong);
            }
        }

        Console.WriteLine($"Playlist '{playlistName}' loaded from {filePath}");
        return loadedPlaylist;
    }


    public void AddSongFromUser()
    {
        Console.Write("Enter Song Title: ");
        string title = Console.ReadLine() ?? "";

        Console.Write("Enter Artist: ");
        string artist = Console.ReadLine() ?? "" ;

        Console.Write("Enter Genre: ");
        string genre = Console.ReadLine() ?? "" ;

        Console.Write("Enter Decade (e.g., 1980, 1990, 2000): ");
        int decade;
        while (!int.TryParse(Console.ReadLine(), out decade))
        {
            Console.Write("Invalid input. Enter a valid decade (e.g., 1990): ");
        }

        Console.Write("Enter Duration (minutes): ");
        double duration;
        while (!double.TryParse(Console.ReadLine(), out duration))
        {
            Console.Write("Invalid input. Enter a valid duration (e.g., 3.5): ");
        }

        Song newSong = new Song(title, artist, genre, decade, duration);
        AddSong(newSong);
    }

    
    public void AddSong(Song song)
    {
        SongNode newNode = new SongNode(song);
        if (head == null)
        {
            head = newNode;
        }
        else
        {
            SongNode temp = head;
            while (temp.Next != null)
            {
                temp = temp.Next;
            }
            temp.Next = newNode;
        }
        Console.WriteLine($"Added {song.Title} to {Name}.");
    }

    
    public void SearchByTitle(string title)
    {
        SongNode temp = head;
        while (temp != null)
        {
            if (temp.Data.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("\nSong Found:");
                temp.Data.DisplaySong();
                return;
            }
            temp = temp.Next;
        }
        Console.WriteLine("\nSong not found.");
    }

    public void SearchByArtist(string artist)
    {
        bool found = false;
        SongNode? temp = head;
        Console.WriteLine($"\nSongs by {artist}:");
        while (temp != null)
        {
            if (temp.Data.Artist.Equals(artist, StringComparison.OrdinalIgnoreCase))
            {
                temp.Data.DisplaySong();
                found = true;
            }
            temp = temp.Next;
        }

        if (!found)
            Console.WriteLine("No songs found by this artist.");
    }

    public void SearchByGenre(string genre)
    {
        bool found = false;
        SongNode? temp = head;
        Console.WriteLine($"\nSongs in {genre} genre:");
        while (temp != null)
        {
            if (temp.Data.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase))
            {
                temp.Data.DisplaySong();
                found = true;
            }
            temp = temp.Next;
        }

        if (!found)
            Console.WriteLine("No songs found in this genre.");
    }

    /*public void SortPlaylist(string criteria)               //Merge Sort
    {
        DateTime startTime = DateTime.Now;

        head = MergeSort(head, criteria);

        DateTime endTime = DateTime.Now;
        TimeSpan duration = endTime - startTime;

        Console.WriteLine($"Merge Sort Execution Time: {duration.TotalMilliseconds} ms");
    }

    private SongNode? MergeSort(SongNode head, string criteria)
    {
        if (head == null || head.Next == null)
            return head;

        SongNode? middle = GetMiddle(head);
        SongNode? nextToMiddle = middle.Next;
        middle.Next = null;

        SongNode? left = MergeSort(head, criteria);
        SongNode? right = MergeSort(nextToMiddle, criteria);

        return Merge(left, right, criteria);
    }

    private SongNode? Merge(SongNode left, SongNode right, string criteria)
    {
        if (left == null) return right;
        if (right == null) return left;

        bool shouldSwap;
        switch (criteria.ToLower())
        {
            case "1":
                shouldSwap = string.Compare(left.Data.Artist, right.Data.Artist, StringComparison.OrdinalIgnoreCase) <= 0;
                break;
            case "2":
                shouldSwap = left.Data.Decade <= right.Data.Decade;
                break;
            case "3":
                shouldSwap = string.Compare(left.Data.Genre, right.Data.Genre, StringComparison.OrdinalIgnoreCase) <= 0;
                break;
            default:
                shouldSwap = true;
                break;
        }

        if (shouldSwap)
        {
            left.Next = Merge(left.Next, right, criteria);
            return left;
        }
        else
        {
            right.Next = Merge(left, right.Next, criteria);
            return right;
        }
    }

    private SongNode? GetMiddle(SongNode head)
    {
        if (head == null) return head;

        SongNode slow = head, fast = head;
        while (fast.Next != null && fast.Next.Next != null)
        {
            slow = slow.Next;
            fast = fast.Next.Next;
        }
        return slow;
    }*/

    /*public void SortPlaylist(string criteria)   //Bubble Sort
    {
        if (head == null || head.Next == null)
            return;

        DateTime startTime = DateTime.Now;

        bool swapped;
        do
        {
            swapped = false;
            SongNode current = head;
            SongNode prev = null;

            while (current.Next != null)
            {
                bool shouldSwap = false;
                switch (criteria.ToLower())
                {
                    case "1":
                        shouldSwap = string.Compare(current.Data.Artist, current.Next.Data.Artist, StringComparison.OrdinalIgnoreCase) > 0;
                        break;
                    case "2":
                        shouldSwap = current.Data.Decade > current.Next.Data.Decade;
                        break;
                    case "3":
                        shouldSwap = string.Compare(current.Data.Genre, current.Next.Data.Genre, StringComparison.OrdinalIgnoreCase) > 0;
                        break;
                }

                if (shouldSwap)
                {
                    // Swap data
                    Song temp = current.Data;
                    current.Data = current.Next.Data;
                    current.Next.Data = temp;
                    swapped = true;
                }
                prev = current;
                current = current.Next;
            }
        } while (swapped);
        
        DateTime endTime = DateTime.Now; // End time tracking
        TimeSpan duration = endTime - startTime;

        Console.WriteLine($"Bubble Sort Execution Time: {duration.TotalMilliseconds} ms");
    }*/

    public void SortPlaylist(string criteria)           //Quick Sort
    {   
        DateTime startTime = DateTime.Now;

        head = QuickSort(head, GetTail(head), criteria);

        DateTime endTime = DateTime.Now;
        TimeSpan duration = endTime - startTime;

        Console.WriteLine($"Quick Sort Execution Time: {duration.TotalMilliseconds} ms");
    }

    private SongNode QuickSort(SongNode head, SongNode tail, string criteria)
    {
        if (head == null || head == tail)
            return head;

        SongNode newHead = null, newTail = null;
        SongNode pivot = Partition(head, tail, ref newHead, ref newTail, criteria);

        if (newHead != pivot)
        {
            SongNode temp = newHead;
            while (temp.Next != pivot)
                temp = temp.Next;
            temp.Next = null;

            newHead = QuickSort(newHead, temp, criteria);

            temp = GetTail(newHead);
            temp.Next = pivot;
        }

        pivot.Next = QuickSort(pivot.Next, newTail, criteria);
        return newHead;
    }

    private SongNode Partition(SongNode head, SongNode tail, ref SongNode newHead, ref SongNode newTail, string criteria)
    {
        SongNode pivot = tail;
        SongNode prev = null, cur = head, tailPtr = pivot;

        while (cur != pivot)
        {
            bool shouldMove = false;
            switch (criteria.ToLower())
            {
                case "1":
                    shouldMove = string.Compare(cur.Data.Artist, pivot.Data.Artist, StringComparison.OrdinalIgnoreCase) < 0;
                    break;
                case "2":
                    shouldMove = cur.Data.Decade < pivot.Data.Decade;
                    break;
                case "3":
                    shouldMove = string.Compare(cur.Data.Genre, pivot.Data.Genre, StringComparison.OrdinalIgnoreCase) < 0;
                    break;
            }

            if (shouldMove)
            {
                if (newHead == null) newHead = cur;
                prev = cur;
                cur = cur.Next;
            }
            else
            {
                if (prev != null) prev.Next = cur.Next;
                SongNode temp = cur.Next;
                cur.Next = null;
                tailPtr.Next = cur;
                tailPtr = cur;
                cur = temp;
            }
        }

        if (newHead == null) newHead = pivot;
        newTail = tailPtr;
        return pivot;
    }

    private SongNode GetTail(SongNode head)
    {
        while (head != null && head.Next != null)
            head = head.Next;
        return head;
    }


    public Song? GetSongByTitle(string title)
    {
        SongNode temp = head;
        while (temp != null)
        {
            if (temp.Data.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
            {
                return temp.Data;
            }
            temp = temp.Next;
        }
        return null;
    }

    public void DisplayPlaylistStats()
    {
        if (head == null)
        {
            Console.WriteLine("Playlist is empty. No statistics available.");
            return;
        }

        Console.WriteLine("\nPlaylist Statistics:");
        Console.WriteLine($"Most Saved Artist: {GetMostSavedArtist()}");
        Console.WriteLine($"Favorite Decade: {GetFavoriteDecade()}");
        Console.WriteLine($"Favorite Genre: {GetFavoriteGenre()}");
    }

    private string GetMostSavedArtist()
    {
        if (head == null) return "N/A";

        SongNode temp = head;
        string mostSavedArtist = "";
        int maxCount = 0;

        
        while (temp != null)
        {
            string currentArtist = temp.Data.Artist;
            int count = 0;
            SongNode check = head;

            while (check != null)
            {
                if (check.Data.Artist == currentArtist)
                    count++;
                check = check.Next;
            }

            if (count > maxCount)
            {
                maxCount = count;
                mostSavedArtist = currentArtist;
            }

            temp = temp.Next;
        }

        return mostSavedArtist;
    }

    private int GetFavoriteDecade()
    {
        if (head == null) return 0;

        SongNode temp = head;
        int favoriteDecade = 0;
        int maxCount = 0;

        while (temp != null)
        {
            int currentDecade = temp.Data.Decade;
            int count = 0;
            SongNode check = head;

            while (check != null)
            {
                if (check.Data.Decade == currentDecade)
                    count++;
                check = check.Next;
            }

            if (count > maxCount)
            {
                maxCount = count;
                favoriteDecade = currentDecade;
            }

            temp = temp.Next;
        }

        return favoriteDecade;
    }

    private string GetFavoriteGenre()
    {
        if (head == null) return "N/A";

        SongNode temp = head;
        string favoriteGenre = "";
        int maxCount = 0;

        while (temp != null)
        {
            string currentGenre = temp.Data.Genre;
            int count = 0;
            SongNode check = head;

            while (check != null)
            {
                if (check.Data.Genre == currentGenre)
                    count++;
                check = check.Next;
            }

            if (count > maxCount)
            {
                maxCount = count;
                favoriteGenre = currentGenre;
            }

            temp = temp.Next;
        }

        return favoriteGenre;
    }

    public void DisplaySongs()
    {
        if (head == null)
        {
            Console.WriteLine($"{Name} is empty.");
            return;
        }

        Console.WriteLine($"\nPlaylist: {Name}");
        SongNode? temp = head;
        while (temp != null)
        {
            temp.Data.DisplaySong();
            temp = temp.Next;
        }
    }
}
