using MusicPlaylistManager;

public class QueueNode
{
    public Song Data; // The song stored in this node
    public QueueNode? Next; // Pointer to the next node in the queue

    public QueueNode(Song song)
    {
        Data = song;
        Next = null;
    }
}
