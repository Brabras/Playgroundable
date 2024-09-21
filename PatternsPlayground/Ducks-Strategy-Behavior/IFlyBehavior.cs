namespace PatternsPlayground.Ducks_Strategy_Behavior;

public interface IFlyBehavior
{
    public void Fly();
}

public sealed class FlyWithWings : IFlyBehavior
{
    public void Fly()
    {
        Console.WriteLine("I'm flying with wings");
    }
}

public sealed class FlyNoWay : IFlyBehavior
{
    public void Fly()
    {
    }
}

public sealed class ReactiveFlying : IFlyBehavior
{
    public void Fly()
    {
        Console.WriteLine("I'm flying like a rocket");
    }
}