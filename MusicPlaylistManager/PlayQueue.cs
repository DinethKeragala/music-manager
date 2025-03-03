using MusicPlaylistManager;

public class PlayQueue
{
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
    private QueueNode? front; // First song in queue
    private QueueNode? rear;  // Last song in queue
=======
    private QueueNode? front; // First song 
    private QueueNode? rear;  // Last song 
>>>>>>> Stashed changes
=======
    private QueueNode? front; // First song 
    private QueueNode? rear;  // Last song 
>>>>>>> Stashed changes
=======
    private QueueNode? front; // First song 
    private QueueNode? rear;  // Last song 
>>>>>>> Stashed changes

    public PlayQueue()
    {
        front = rear = null;
    }

    //  Add a song to the queue (Enqueue)
    public void Enqueue(Song song)
    {
        QueueNode newNode = new QueueNode(song);
        if (rear == null)
        {
            front = rear = newNode;
        }
        else
        {
            rear.Next = newNode;
            rear = newNode;
        }
        Console.WriteLine($"{song.Title} added to play queue.");
    }

    // Play the next song (Dequeue)
    public void PlayNext()
    {
        if (front == null)
        {
            Console.WriteLine("Play queue is empty.");
            return;
        }

        Console.WriteLine("Now Playing:");
        front.Data.DisplaySong();
        front = front.Next;

        if (front == null) // If queue is empty after playing
            rear = null;
    }

    //  Show queue
    public void DisplayQueue()
    {
        if (front == null)
        {
            Console.WriteLine("Play queue is empty.");
            return;
        }

        Console.WriteLine("\nPlay Queue:");
        QueueNode? temp = front;
        while (temp != null)
        {
            temp.Data.DisplaySong();
            if(temp.Next == null) 
                break;
            temp = temp.Next;
        }
    }
}
