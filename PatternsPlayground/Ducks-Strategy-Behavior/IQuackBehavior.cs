namespace PatternsPlayground.Ducks_Strategy_Behavior;

public interface IQuackBehavior
{
    public void Quack();
}

public sealed class RegularQuack : IQuackBehavior
{
    public void Quack()
    {
        Console.WriteLine("Quack");
    }
}

public sealed class Squack : IQuackBehavior
{
    public void Quack()
    {
        Console.WriteLine("Squack");
    }
}

public sealed class MuteQuack : IQuackBehavior
{
    public void Quack()
    {
    }
}