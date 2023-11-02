using System.Diagnostics.CodeAnalysis;

namespace Infrastructure.Seedwork.DataTypes;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public sealed class Currency : EnumObject
{
    private const string KGSKey = "KGS";
    private const string KZTKey = "KZT";

    public static readonly Currency KGS = new(KGSKey, "KGS");
    public static readonly Currency KZT = new(KZTKey, "KZT");

    public static readonly Currency Base = KGS;

    private Currency(string key, string name)
        : base(key, name)
    {
    }

    public override string ToString()
    {
        return Name;
    }

    public static Currency Create(string type)
    {
        return type switch
        {
            KGSKey => KGS,
            KZTKey => KZT,
            _ => throw new InvalidOperationException($"Unsupported type '{type}'")
        };
    }

}