using System.Globalization;
using CSharpFunctionalExtensions;

namespace Infrastructure.Seedwork.DataTypes;

public class Date : SingleValueObject<DateTime>
{
    private const string Format = "yyyy-MM-dd";

    public Date(int year, int month, int day)
        : base(new DateTime(year, month, day))
    {
    }

    private Date(DateTime value) : base(value)
    {
    }

    public UtcDateTime UtcStartOfTheDay(TimeZoneInfo timeZone)
    {
        var dateTime = new DateTime(Value.Year, Value.Month, Value.Day);
        return TimeZoneInfo.ConvertTime(dateTime, timeZone, TimeZoneInfo.Utc);
    }

    public UtcDateTime UtcStartOfTheMonth(TimeZoneInfo timezone)
    {
        var dateTime = new DateTime(Value.Year, Value.Month, 1);

        return TimeZoneInfo.ConvertTime(dateTime, timezone, TimeZoneInfo.Utc);
    }

    public Date AddDays(double value)
    {
        return Value.AddDays(value);
    }

    public Date AddMonths(int monthsNumber)
    {
        return Value.AddMonths(monthsNumber);
    }

    public Date AddYears(int yearsNumber)
    {
        return Value.AddYears(yearsNumber);
    }

    public override string ToString()
    {
        return Value.ToString(Format);
    }

    public static implicit operator Date(DateTime dateTime)
    {
        if (dateTime.Hour != 0 || dateTime.Minute != 0 || dateTime.Second != 0 || dateTime.Millisecond != 0)
            throw new InvalidOperationException(
                $"Date must not contain time. DateTime: {dateTime:yyyy.MM.dd HH:mm:ss fffffff}");

        return new Date(dateTime.Date);
    }

    public static explicit operator Date(string value)
    {
        var result = Create(value);

        if (result.IsFailure)
            throw new InvalidOperationException(result.Error);

        return result.Value;
    }

    public static bool operator <=(Date value, Date otherValue)
    {
        return value.Value <= otherValue.Value;
    }

    public static bool operator >=(Date value, Date otherValue)
    {
        return value.Value >= otherValue.Value;
    }

    public static Result<Date, string> Create(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return "FillFieldMessage";

        if (!DateTime.TryParseExact(value, Format, CultureInfo.InvariantCulture, DateTimeStyles.None, out var dateTime))
        {
            return "WrongFormat";
        }

        return new Date(dateTime);
    }

    public string FormatRuDate()
    {
        return Value.ToString("dd.MM.yyyy", CultureInfo.GetCultureInfo("ru-RU"));
    }
}