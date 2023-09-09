namespace LinkedList;

public class LinkedListNode<T>
{
    public T Value { get; private set; }

    public T? Next { get; private set; }

    internal LinkedListNode(T value, T next)
    {
        Value = value;
        Next = next;
    }
}