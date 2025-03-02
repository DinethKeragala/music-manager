using System.Text;
using MusicPlaylistManager;

public class Playlist
{
    public string Name { get; set; }
    private SongNode head; // Head of the linked list

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
        csvContent.AppendLine("Title,Artist,Genre,Decade,Duration"); // CSV Header

        SongNode temp = head;
        while (temp != null)
        {
            csvContent.AppendLine($"{temp.Data.Title},{temp.Data.Artist},{temp.Data.Genre},{temp.Data.Decade},{temp.Data.Duration}");
            temp = temp.Next;
        }

        File.WriteAllText(filePath, csvContent.ToString());
        Console.WriteLine($"Playlist exported to {filePath}");
    }

    public void LoadFromCSV(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("No previous playlist found.");
            return;
        }

        string[] lines = File.ReadAllLines(filePath);
        if (lines.Length <= 1) // No song data
        {
            Console.WriteLine("Playlist file is empty.");
            return;
        }

        for (int i = 1; i < lines.Length; i++) // Skip header
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
                AddSong(newSong);
            }
        }

        Console.WriteLine($"Playlist loaded from {filePath}");
    }
    // Allow user to enter a song from console
    public void AddSongFromUser()
    {
        Console.Write("Enter Song Title: ");
        string title = Console.ReadLine();

        Console.Write("Enter Artist: ");
        string artist = Console.ReadLine();

        Console.Write("Enter Genre: ");
        string genre = Console.ReadLine();

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

        // Create song and add to playlist
        Song newSong = new Song(title, artist, genre, decade, duration);
        AddSong(newSong);
    }

    // Add a song to the linked list
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

    // Search by Title
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

    // Search by Artist
    public void SearchByArtist(string artist)
    {
        bool found = false;
        SongNode temp = head;
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

    // Search by Genre
    public void SearchByGenre(string genre)
    {
        bool found = false;
        SongNode temp = head;
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

    public void SortPlaylist(string sortBy, string sortMethod)
    {
        switch (sortMethod.ToLower())
        {
            case "bubble":
                BubbleSort(sortBy);
                break;
            case "merge":
                head = MergeSort(head, sortBy);
                break;
            case "quick":
                head = QuickSort(head, null, sortBy);
                break;
            default:
                Console.WriteLine("Invalid sorting method.");
                return;
        }
        Console.WriteLine($"Songs sorted by {sortBy} using {sortMethod} sort.");
    }

    // Bubble Sort for sorting by Title, Genre, or Decade
    private void BubbleSort(string sortBy)
    {
        if (head == null || head.Next == null)
        {
            Console.WriteLine("Not enough songs to sort.");
            return;
        }

        bool swapped;
        do
        {
            swapped = false;
            SongNode current = head;
            while (current.Next != null)
            {
                if (CompareSongs(current.Data, current.Next.Data, sortBy) > 0)
                {
                    // Swap songs
                    Song temp = current.Data;
                    current.Data = current.Next.Data;
                    current.Next.Data = temp;
                    swapped = true;
                }
                current = current.Next;
            }
        } while (swapped);

        Console.WriteLine($"Songs sorted by {sortBy} using Bubble Sort.");
    }

    // Merge Sort for sorting by Title, Genre, or Decade
    private SongNode MergeSort(SongNode node, string sortBy)
    {
        if (node == null || node.Next == null)
            return node;

        SongNode middle = GetMiddle(node);
        SongNode nextOfMiddle = middle.Next;
        middle.Next = null;

        SongNode left = MergeSort(node, sortBy);
        SongNode right = MergeSort(nextOfMiddle, sortBy);

        return Merge(left, right, sortBy);
    }

    private SongNode Merge(SongNode left, SongNode right, string sortBy)
    {
        if (left == null) return right;
        if (right == null) return left;

        if (CompareSongs(left.Data, right.Data, sortBy) <= 0)
        {
            left.Next = Merge(left.Next, right, sortBy);
            return left;
        }
        else
        {
            right.Next = Merge(left, right.Next, sortBy);
            return right;
        }
    }

    // Quick Sort for sorting by Title, Genre, or Decade
    private SongNode QuickSort(SongNode start, SongNode end, string sortBy)
    {
        if (start == null || start == end)
            return start;

        SongNode newHead = null, newEnd = null;
        SongNode pivot = Partition(start, end, ref newHead, ref newEnd, sortBy);

        if (newHead != pivot)
        {
            SongNode temp = newHead;
            while (temp.Next != pivot)
                temp = temp.Next;
            temp.Next = null;

            newHead = QuickSort(newHead, temp, sortBy);
            temp = GetTail(newHead);
            temp.Next = pivot;
        }

        pivot.Next = QuickSort(pivot.Next, newEnd, sortBy);
        return newHead;
    }

    private SongNode Partition(SongNode start, SongNode end, ref SongNode newHead, ref SongNode newEnd, string sortBy)
    {
        SongNode pivot = end, prev = null, curr = start, tail = pivot;
        while (curr != pivot)
        {
            if (CompareSongs(curr.Data, pivot.Data, sortBy) < 0)
            {
                if (newHead == null)
                    newHead = curr;
                prev = curr;
                curr = curr.Next;
            }
            else
            {
                if (prev != null)
                    prev.Next = curr.Next;
                SongNode temp = curr.Next;
                curr.Next = null;
                tail.Next = curr;
                tail = curr;
                curr = temp;
            }
        }
        if (newHead == null)
            newHead = pivot;
        newEnd = tail;
        return pivot;
    }

    private SongNode GetMiddle(SongNode node)
    {
        if (node == null) return node;
        SongNode slow = node, fast = node;
        while (fast.Next != null && fast.Next.Next != null)
        {
            slow = slow.Next;
            fast = fast.Next.Next;
        }
        return slow;
    }

    private SongNode GetTail(SongNode node)
    {
        while (node != null && node.Next != null)
            node = node.Next;
        return node;
    }

    // Compare two songs based on the selected sort criterion
    private int CompareSongs(Song song1, Song song2, string sortBy)
    {
        return sortBy.ToLower() switch
        {
            "title" => string.Compare(song1.Title, song2.Title, StringComparison.OrdinalIgnoreCase),
            "genre" => string.Compare(song1.Genre, song2.Genre, StringComparison.OrdinalIgnoreCase),
            "decade" => song1.Decade.CompareTo(song2.Decade),
            _ => 0,
        };
    }
    public Song GetSongByTitle(string title)
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

        // Loop through each song and count how many times its artist appears
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

    // Display all songs in the playlist
    public void DisplaySongs()
    {
        if (head == null)
        {
            Console.WriteLine($"{Name} is empty.");
            return;
        }

        Console.WriteLine($"\nPlaylist: {Name}");
        SongNode temp = head;
        while (temp != null)
        {
            temp.Data.DisplaySong();
            temp = temp.Next;
        }
    }
}
