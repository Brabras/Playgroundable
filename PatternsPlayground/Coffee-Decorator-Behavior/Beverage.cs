namespace PatternsPlayground.Coffee_Decorator_Behavior;

public abstract class Beverage(string description)
{
    public string Description { get; init; } = description;

    public abstract decimal GetCost();
}

public sealed class HouseBlend(string description) : Beverage(description)
{
    public override decimal GetCost()
    {
        return 1.1M;
    }
} 