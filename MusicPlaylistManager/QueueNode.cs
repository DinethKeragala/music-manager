using MusicPlaylistManager;

public class QueueNode
{
    public Song? Data; 
    public QueueNode? Next; 

    public QueueNode(Song song)
    {
        Data = song;
        Next = null;
    }
}
