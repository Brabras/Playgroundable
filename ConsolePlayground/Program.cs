using System.Text.Json;
using ConsolePlayground;

var cl = (new Foo
{
    Id   = 1,
    Name = "Foo"
}, new Bar
{
    Id = 2,
    Child = new Child
    {
        Id   = 3,
        Name = "Child"
    },
    Data = "test"
});

var serialized = SpectrJsonSerializer.Serialize(cl.Item2);

Console.WriteLine(serialized);

public sealed class Foo
{
    public long Id { get; set; }
    
    public string Name { get; set; }
}

public sealed class Bar
{
    public long Id { get; set; }
    
    public Child Child { get; set; }
    
    public string Data { get; set; }
}

public sealed class Child
{
    public long Id { get; set; }
    
    public string Name { get; set; }
}