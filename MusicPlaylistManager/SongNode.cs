using MusicPlaylistManager;

public class SongNode
{
    public Song Data;
    public SongNode Next;

    public SongNode(Song song)
    {
        Data = song;
        Next = null;
    }
}
