using MusicPlaylistManager;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("WELCOME TO THE MUSIC PLAYLIST MANAGER");

        Console.Write("Enter Playlist Name: ");
        string playlistName = Console.ReadLine() ?? "";
        string filePath = $"{playlistName}.csv"; 

        Playlist myPlaylist;

        if (File.Exists(filePath))
        {
            myPlaylist = Playlist.LoadFromCSV(filePath);
            Console.WriteLine($"Loaded existing playlist: {playlistName}");
        }
        else
        {
            myPlaylist = new Playlist(playlistName);
            Console.WriteLine($"Created new playlist: {playlistName}");
        }

        PlayQueue playQueue = new PlayQueue();

        while (true)
        {
            Console.WriteLine("\nMENU");
            Console.WriteLine("1 Add a Song");
            Console.WriteLine("2 Show Playlist");
            Console.WriteLine("3 Search Song by Title");
            Console.WriteLine("4 Search Songs by Artist");
            Console.WriteLine("5 Search Songs by Genre");
            Console.WriteLine("6 Sort Playlist");
            Console.WriteLine("7 Play Songs");
            Console.WriteLine("8 View Playlist Statistics");
            Console.WriteLine("9 Save Playlist & Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine() ??"";

            switch (choice)
            {
                case "1":
                    myPlaylist.AddSongFromUser();
                    break;
                case "2":
                    myPlaylist.DisplaySongs();
                    break;
                case "3":
                    Console.Write("Enter Song Title: ");
                    myPlaylist.SearchByTitle(Console.ReadLine() ?? "");
                    break;
                case "4":
                    Console.Write("Enter Artist Name: ");
                    myPlaylist.SearchByArtist(Console.ReadLine() ?? "");
                    break;
                case "5":
                    Console.Write("Enter Genre: ");
                    myPlaylist.SearchByGenre(Console.ReadLine() ?? "");
                    break;
                case "6":
                    Console.WriteLine("\nSort Playlist by:");
                    Console.WriteLine("1 Artist");
                    Console.WriteLine("2 Decade");
                    Console.WriteLine("3 Genre");
                    Console.Write("Enter choice: ");
                    string sortChoice = Console.ReadLine() ?? "";

                    if (!string.IsNullOrEmpty(sortChoice))
                    {
                        myPlaylist.SortPlaylist(sortChoice);
                        if (sortChoice == "1")
                            Console.WriteLine($"Playlist sorted by Artist.");
                        if (sortChoice == "2")
                            Console.WriteLine($"Playlist sorted by Decade.");
                        if (sortChoice == "3")
                            Console.WriteLine($"Playlist sorted by Genre.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice.");
                    }
                    break;
                case "7":
                    Console.WriteLine("\nPlay Songs Menu:");
                    Console.WriteLine("1 Add Song to Play Queue");
                    Console.WriteLine("2 Play Next Song");
                    Console.WriteLine("3 View Play Queue");
                    Console.Write("Enter choice: ");
                    string playChoice = Console.ReadLine() ?? "";

                    switch (playChoice)
                    {
                        case "1":
                            Console.Write("Enter Song Title to Add to Queue: ");
                            string songTitle = Console.ReadLine() ?? "" ;
                            Song foundSong = myPlaylist.GetSongByTitle(songTitle);
                            if (foundSong != null)
                            {
                                playQueue.Enqueue(foundSong);
                            }
                            else
                            {
                                Console.WriteLine("Song not found in the playlist.");
                            }
                            break;
                        case "2":
                            playQueue.PlayNext();
                            break;
                        case "3":
                            playQueue.DisplayQueue();
                            break;
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                    break;
                case "8":
                    myPlaylist.DisplayPlaylistStats();
                    break;
                case "9":
                    myPlaylist.ExportToCSV(filePath);
                    Console.WriteLine($"Playlist '{playlistName}' saved to {filePath}. Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
