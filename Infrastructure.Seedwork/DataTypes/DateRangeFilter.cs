using JetBrains.Annotations;

namespace Infrastructure.Seedwork.DataTypes;

public sealed class DateRangeType : EnumObject
{
    private const string ExactDateKey = "DATE";
    private const string DateRangeKey = "RANGE";

    public static readonly DateRangeType ExactDate = new(ExactDateKey, "Дата");
    public static readonly DateRangeType DateRange = new(DateRangeKey, "Интервал");

    private DateRangeType(string key, string name)
        : base(key, name)
    {
    }

    [UsedImplicitly]
    public static DateRangeType Create(string key)
    {
        return key.ToUpper() switch
        {
            ExactDateKey => ExactDate,
            DateRangeKey => DateRange,
            _ => throw new InvalidOperationException($"Unsupported key '{key}'")
        };
    }
}