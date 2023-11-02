namespace LinkedList;

public class LinkedListNode<T>
{
    public T Value { get; internal set; }

    public LinkedListNode<T>? Next { get; internal set; }

    internal LinkedListNode(T value, LinkedListNode<T>? next = null)
    {
        Value = value;
        Next = next;
    }

    internal LinkedListNode(T value)
    {
        Value = value;
    }
}