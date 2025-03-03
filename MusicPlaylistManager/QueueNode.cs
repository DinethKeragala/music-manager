using MusicPlaylistManager;

public class QueueNode
{
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
    public Song Data; // The song stored in this node
    public QueueNode? Next; // Pointer to the next node in the queue
=======
    public Song? Data; 
    public QueueNode? Next; 
>>>>>>> Stashed changes
=======
    public Song? Data; 
    public QueueNode? Next; 
>>>>>>> Stashed changes
=======
    public Song? Data; 
    public QueueNode? Next; 
>>>>>>> Stashed changes

    public QueueNode(Song song)
    {
        Data = song;
        Next = null;
    }
}
