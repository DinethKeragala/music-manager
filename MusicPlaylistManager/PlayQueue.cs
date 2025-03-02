using MusicPlaylistManager;

public class PlayQueue
{
    private QueueNode front; // First song in queue
    private QueueNode rear;  // Last song in queue

    public PlayQueue()
    {
        front = rear = null;
    }

    
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

        if (front == null) 
            rear = null;
    }

    
    public void DisplayQueue()
    {
        if (front == null)
        {
            Console.WriteLine("Play queue is empty.");
            return;
        }

        Console.WriteLine("\nPlay Queue:");
        QueueNode temp = front;
        while (temp != null)
        {
            temp.Data.DisplaySong();
            temp = temp.Next;
        }
    }
}
