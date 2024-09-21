namespace PatternsPlayground.Ducks_Strategy_Behavior;

public sealed class MallardDuck : Duck
{
    private MallardDuck(IFlyBehavior flyBehavior, IQuackBehavior quackBehavior) : base(flyBehavior, quackBehavior)
    {
    }

    public override void Display()
    {
        Console.WriteLine("I'm looking like a mallard duck");
    }

    public static MallardDuck CreateMallardDuck()
    {
        return new MallardDuck(new FlyWithWings(), new RegularQuack());
    }
}