namespace PatternsPlayground.Coffee_Decorator_Behavior;

public abstract class CondimentDecorator : Beverage
{
    protected Beverage Beverage { get; init; } = null!;
    
    public abstract override string GetDescription();
}

public sealed class Mocha : CondimentDecorator
{
    private Mocha()
    {
    }

    public override string GetDescription()
    {
        return Beverage.GetDescription() + " Mocha";
    }

    public override decimal Cost()
    {
        return CupSize switch
        {
            CupSize.Small => Beverage.Cost() + .10M,
            CupSize.Middle => Beverage.Cost() + .20M,
            CupSize.Large => Beverage.Cost() + .30M,
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public static Mocha AddToBeverage(Beverage beverage)
    {
        return new Mocha
        {
            Beverage = beverage,
            CupSize = beverage.CupSize
        };
    }
}

public sealed class Soy : CondimentDecorator
{
    private Soy()
    {
    }

    public override string GetDescription()
    {
        return Beverage.GetDescription() + " Soy";
    }

    public override decimal Cost()
    {
        return CupSize switch
        {
            CupSize.Small => Beverage.Cost() + .20M,
            CupSize.Middle => Beverage.Cost() + .40M,
            CupSize.Large => Beverage.Cost() + .60M,
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public static Soy AddToBeverage(Beverage beverage)
    {
        return new Soy
        {
            Beverage = beverage,
            CupSize = beverage.CupSize
        };
    }
}

public sealed class Whip : CondimentDecorator
{
    private Whip()
    {
    }

    public override string GetDescription()
    {
        return Beverage.GetDescription() + " Whip";
    }

    public override decimal Cost()
    {
        return CupSize switch
        {
            CupSize.Small => Beverage.Cost() + .30M,
            CupSize.Middle => Beverage.Cost() + .60M,
            CupSize.Large => Beverage.Cost() + .90M,
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public static Whip AddToBeverage(Beverage beverage)
    {
        return new Whip
        {
            Beverage = beverage,
            CupSize = beverage.CupSize
        };
    }
}