namespace PatternsPlayground.Coffee_Decorator_Behavior;

public enum CupSize
{
    Small = 1,
    Middle = 2,
    Large = 3
}

public abstract class Beverage
{
    protected string Description = null!;

    public CupSize CupSize { get; protected init; }

    public virtual string GetDescription()
    {
        return Description;
    }

    public abstract decimal Cost();
}

public sealed class Espresso : Beverage
{
    private Espresso()
    {
    }

    public override decimal Cost()
    {
        return CupSize switch
        {
            CupSize.Small => 1.00M,
            CupSize.Middle => 2.00M,
            CupSize.Large => 3.00M,
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public static Espresso Create(CupSize size)
    {
        return new Espresso
        {
            CupSize     = size,
            Description = size + " Espresso"
        };
    }
}

public sealed class HouseBlend : Beverage
{
    private HouseBlend()
    {
    }

    public override decimal Cost()
    {
        return CupSize switch
        {
            CupSize.Small => 2.00M,
            CupSize.Middle => 4.00M,
            CupSize.Large => 6.00M,
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public static HouseBlend Create(CupSize size)
    {
        return new HouseBlend
        {
            CupSize     = size,
            Description = size + " HouseBlend"
        };
    }
}

public sealed class DarkRoast : Beverage
{
    private DarkRoast()
    {
    }

    public override decimal Cost()
    {
        return CupSize switch
        {
            CupSize.Small => 3.00M,
            CupSize.Middle => 6.00M,
            CupSize.Large => 9.00M,
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public static DarkRoast Create(CupSize size)
    {
        return new DarkRoast
        {
            CupSize     = size,
            Description = size + " DarkRoast"
        };
    }
}