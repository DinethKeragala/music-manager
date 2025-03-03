using System;

namespace MusicPlaylistManager
{
    public class Song
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Genre { get; set; }
        public int Decade { get; set; } 
        public double Duration { get; set; } 

        public Song(string title, string artist, string genre, int decade, double duration)
        {
            Title = title;
            Artist = artist;
            Genre = genre;
            Decade = decade;
            Duration = duration;
        }

        public void DisplaySong()
        {
            Console.WriteLine($"{Title} by {Artist} | Genre: {Genre} | Decade: {Decade} | Duration: {Duration} min");
        }
    }
}
