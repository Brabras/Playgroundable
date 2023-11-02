namespace Infrastructure.Seedwork.DataTypes;

public sealed class MaritalStatus : EnumObject
{
    private const string NotMarriedKey = "NMR";
    private const string MarriedKey = "MAR";
    private const string DivorcedKey = "DIV";
    private const string WidowKey = "WID";

    public static readonly MaritalStatus NotMarried = new(NotMarriedKey, "Не женат");
    public static readonly MaritalStatus Married = new(MarriedKey, "Женат");
    public static readonly MaritalStatus Divorced = new(DivorcedKey, "Разведен");
    public static readonly MaritalStatus Widow = new(WidowKey, "Вдовец");

    public MaritalStatus(string key, string name) : base(key, name)
    {
    }

    public static MaritalStatus Create(string key)
    {
        return key switch
        {
            NotMarriedKey => NotMarried,
            MarriedKey => Married,
            DivorcedKey => Divorced,
            WidowKey => Widow,

            _ => throw new InvalidOperationException($"Unsupported key '{key}'")
        };
    }

    public static implicit operator MaritalStatus(string key)
    {
        return Create(key);
    }
}