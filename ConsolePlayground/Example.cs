namespace ConsolePlayground;

public class Example
{
    public long Id { get; set; }

    public Example(long id)
    {
        Id = id;
    }
}

public class BrabrasExt
{
    public string Id { get; set; } = null!;
}

public static class ExampleExtensions
{
    public static BrabrasExt ToBrabrasExt(this Example? example)
    {
        if (example is null)
            return null!;

        return new BrabrasExt
        {
            Id = example.Id.ToString()
        };
    }
}