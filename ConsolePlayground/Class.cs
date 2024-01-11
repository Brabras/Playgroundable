namespace ConsolePlayground;

public class Parent
{
    public string Value { get; private set; }

    public Parent(string str)
    {
        Value = str;
    }
}

public class Child : Parent
{
    public readonly long Major;
    public readonly long Minor;
    public Child(string str) : base(str)
    {
        var splits = Value.Split('.');
        Major = Convert.ToInt64(splits[0]);
        Minor = Convert.ToInt64(splits[1]);
    }
}