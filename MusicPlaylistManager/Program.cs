using MusicPlaylistManager;

class Program
{
    static void Main(string[] args)
    {
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
        Console.Write("Enter Playlist Name: ");
        string? playlistName = Console.ReadLine();
        playlistName = playlistName ?? "Default Playlist";
        Playlist myPlaylist = new Playlist(playlistName);
=======
        Console.WriteLine("WELCOME TO THE MUSIC PLAYLIST MANAGER");
>>>>>>> Stashed changes
=======
        Console.WriteLine("WELCOME TO THE MUSIC PLAYLIST MANAGER");
>>>>>>> Stashed changes
=======
        Console.WriteLine("WELCOME TO THE MUSIC PLAYLIST MANAGER");
>>>>>>> Stashed changes

        Console.Write("Enter Playlist Name: ");
        string playlistName = Console.ReadLine() ??"";
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
            Console.WriteLine("6 Sort Songs");
            Console.WriteLine("7 Play Songs");
            Console.WriteLine("8 View Playlist Statistics");
            Console.WriteLine("9 Save Playlist & Exit");
            Console.Write("Choose an option: ");

<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
            string? choice = Console.ReadLine();
=======
            string choice = Console.ReadLine() ?? "";
>>>>>>> Stashed changes
=======
            string choice = Console.ReadLine() ?? "";
>>>>>>> Stashed changes
=======
            string choice = Console.ReadLine() ?? "";
>>>>>>> Stashed changes

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
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
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
=======
                    myPlaylist.SearchByTitle(Console.ReadLine() ?? "");
                    break;
                case "4":
                    Console.Write("Enter Artist Name: ");
                    myPlaylist.SearchByArtist(Console.ReadLine() ?? "");
                    break;
                case "5":
                    Console.Write("Enter Genre: ");
=======
                    myPlaylist.SearchByTitle(Console.ReadLine() ?? "");
                    break;
                case "4":
                    Console.Write("Enter Artist Name: ");
                    myPlaylist.SearchByArtist(Console.ReadLine() ?? "");
                    break;
                case "5":
                    Console.Write("Enter Genre: ");
>>>>>>> Stashed changes
=======
                    myPlaylist.SearchByTitle(Console.ReadLine() ?? "");
                    break;
                case "4":
                    Console.Write("Enter Artist Name: ");
                    myPlaylist.SearchByArtist(Console.ReadLine() ?? "");
                    break;
                case "5":
                    Console.Write("Enter Genre: ");
>>>>>>> Stashed changes
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
                        Console.WriteLine($"Playlist sorted by {sortChoice}.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice.");
                    }
>>>>>>> Stashed changes
                    break;
                case "7":
                    Console.WriteLine("\nPlay Songs Menu:");
                    Console.WriteLine("1 Add Song to Play Queue");
                    Console.WriteLine("2 Play Next Song");
                    Console.WriteLine("3 View Play Queue");
                    Console.Write("Enter choice: ");
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
                    string playChoice = Console.ReadLine() ?? "3";
=======
                    string playChoice = Console.ReadLine() ?? "";
>>>>>>> Stashed changes
=======
                    string playChoice = Console.ReadLine() ?? "";
>>>>>>> Stashed changes
=======
                    string playChoice = Console.ReadLine() ?? "";
>>>>>>> Stashed changes

                    switch (playChoice)
                    {
                        case "1":
                            Console.Write("Enter Song Title to Add to Queue: ");
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
                            string? songTitle = Console.ReadLine() ?? "";
=======
                            string songTitle = Console.ReadLine() ?? "";
>>>>>>> Stashed changes
=======
                            string songTitle = Console.ReadLine() ?? "";
>>>>>>> Stashed changes
=======
                            string songTitle = Console.ReadLine() ?? "";
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
                    myPlaylist.ExportToCSV(filePath); // Save playlist before exiting
                    Console.WriteLine("Exiting...");
=======
                    myPlaylist.ExportToCSV(filePath);
                    Console.WriteLine($"Playlist '{playlistName}' saved to {filePath}. Exiting...");
>>>>>>> Stashed changes
=======
                    myPlaylist.ExportToCSV(filePath);
                    Console.WriteLine($"Playlist '{playlistName}' saved to {filePath}. Exiting...");
>>>>>>> Stashed changes
=======
                    myPlaylist.ExportToCSV(filePath);
                    Console.WriteLine($"Playlist '{playlistName}' saved to {filePath}. Exiting...");
>>>>>>> Stashed changes
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
