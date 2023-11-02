namespace Infrastructure.Seedwork.DataTypes;

public class Country
{
    public const string KyrgyzstanCode = "KGZ";

    public virtual string Code { get; protected init; } = null!;

    public virtual string Name { get; protected init; } = null!;

    protected Country()
    {
    }
}