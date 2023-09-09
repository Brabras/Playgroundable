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
        var newNode = LinkedListNode<T>.Create(value, Head.Value);
        Head = newNode;

        Tail ??= newNode;

        return this;
    }
}