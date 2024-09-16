namespace PatternsPlayground.Ducks;

public abstract class Duck(IFlyBehavior flyBehavior, IQuackBehavior quackBehavior)
{
    private IFlyBehavior FlyBehavior { get; set; } = flyBehavior;

    private IQuackBehavior QuackBehavior { get; set; } = quackBehavior;

    public void Quack()
    {
        QuackBehavior.Quack();
    }

    public void Fly()
    {
        FlyBehavior.Fly();
    }

    public abstract void Display();

    public void SetFlyBehavior(IFlyBehavior flyBehavior)
    {
        FlyBehavior = flyBehavior;
    }

    public void SetQuackBehavior(IQuackBehavior quackBehavior)
    {
        QuackBehavior = quackBehavior;
    }
}