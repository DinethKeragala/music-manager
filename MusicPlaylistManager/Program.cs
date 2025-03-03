using MusicPlaylistManager;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter Playlist Name: ");
        string? playlistName = Console.ReadLine();
        playlistName = playlistName ?? "Default Playlist";
        Playlist myPlaylist = new Playlist(playlistName);

        string filePath = "songs.csv"; // Default CSV file
        myPlaylist.LoadFromCSV(filePath); // Load saved songs

        PlayQueue playQueue = new PlayQueue();

        while (true)
        {
            Console.WriteLine("\nMUSIC PLAYLIST MANAGER");
            Console.WriteLine("1 Add a Song");
            Console.WriteLine("2 Show Playlist");
            Console.WriteLine("3 Search Song by Title");
            Console.WriteLine("4 Search Songs by Artist");
            Console.WriteLine("5 Search Songs by Genre");
            Console.WriteLine("6 Sort Songs");
            Console.WriteLine("7 Play Songs");
            Console.WriteLine("8 View Playlist Statistics");
            Console.WriteLine("9 Save Playlist & Exit");
            Console.Write("Choose an option: ");

            string? choice = Console.ReadLine();

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
                    string title = Console.ReadLine() ?? "";
                    myPlaylist.SearchByTitle(title);
                    break;
                case "4":
                    Console.Write("Enter Artist Name: ");
                    string artist = Console.ReadLine() ?? "";
                    myPlaylist.SearchByArtist(artist);
                    break;
                case "5":
                    Console.Write("Enter Genre: ");
                    string genre = Console.ReadLine() ?? "";
                    myPlaylist.SearchByGenre(genre);
                    break;
                case "6":
                    Console.WriteLine("\nChoose Sorting Option:");
                    Console.WriteLine("1 Sort by Title");
                    Console.WriteLine("2 Sort by Genre");
                    Console.WriteLine("3 Sort by Decade");
                    Console.Write("Enter sorting criterion: ");
                    string sortBy = Console.ReadLine() ?? "1";

                    Console.WriteLine("\nChoose Sorting Method:");
                    Console.WriteLine("1 Bubble Sort");
                    Console.WriteLine("2 Merge Sort");
                    Console.WriteLine("3 Quick Sort");
                    Console.Write("Enter sorting method: ");
                    string sortMethod = Console.ReadLine() ?? "1";

                    // Call the new method to handle the sorting logic
                    myPlaylist.SortPlaylist(sortBy, sortMethod);
                    break;
                case "7":
                    Console.WriteLine("\nPlay Songs Menu:");
                    Console.WriteLine("1 Add Song to Play Queue");
                    Console.WriteLine("2 Play Next Song");
                    Console.WriteLine("3 View Play Queue");
                    Console.Write("Enter choice: ");
                    string playChoice = Console.ReadLine() ?? "3";

                    switch (playChoice)
                    {
                        case "1":
                            Console.Write("Enter Song Title to Add to Queue: ");
                            string? songTitle = Console.ReadLine() ?? "";
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
                    myPlaylist.ExportToCSV(filePath); // Save playlist before exiting
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
