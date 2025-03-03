using System;

namespace MusicPlaylistManager
{
    // Song Class (Represents a Song)
    public class Song
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Genre { get; set; }
        public int Decade { get; set; } // Example: 1980, 1990, 2000
        public double Duration { get; set; } // Duration in minutes

        public Song(string title, string artist, string genre, int decade, double duration)
        {
            Title = title;
            Artist = artist;
            Genre = genre;
            Decade = decade;
            Duration = duration;
        }

        // Display song details
        public void DisplaySong()
        {
            Console.WriteLine($"{Title} by {Artist} | Genre: {Genre} | Decade: {Decade} | Duration: {Duration} min");
        }
    }
}
