namespace LinkedList;

public class LinkedList<T>
{
    public LinkedListNode<T>? Head { get; private set; }

    public LinkedListNode<T>? Tail { get; private set; }

    public LinkedList()
    {
    }

    public LinkedList<T> Prepend(T value)
    {
        var newNode = new LinkedListNode<T>(value, Head);
        Head = newNode;

        Tail ??= newNode;

        return this;
    }

    public LinkedList<T> Append(T value)
    {
        var newNode = new LinkedListNode<T>(value);

        if (Head is null)
        {
            Head = newNode;
            Tail = newNode;

            return this;
        }
        
        Tail = newNode;
        Tail.Next = newNode;

        return this;
    }

    public LinkedList<T> Insert(T value, long rawIndex)
    {
        var index = rawIndex < 0 ? 0 : rawIndex;

        if (index == 0)
            Prepend(value);
        else
        {
            var count = 1;
            var currentNode = Head;
            var newNode = new LinkedListNode<T>(value);
            while (currentNode is not null)
            {
                if (count == index)
                    break;

                currentNode = currentNode.Next;
                ++count;
            }

            if (currentNode is not null)
            {
                newNode.Next = currentNode.Next;
                currentNode.Next = newNode;
            }
            else
            {
                if (Tail is not null)
                {
                    Tail.Next = newNode;
                    Tail = newNode;
                }
                else
                {
                    Head = newNode;
                    Tail = newNode;
                }
            }
        }

        return this;
    }
}