namespace Infrastructure.Seedwork.DataTypes;

public sealed class DayOfWeek : EnumObject
{
    private const string MondayKey = "MON";
    private const string TuesdayKey = "TUE";
    private const string WednesdayKey = "WED";
    private const string ThursdayKey = "THU";
    private const string FridayKey = "FRI";
    private const string SaturdayKey = "SAT";
    private const string SundayKey = "SUN";

    public static readonly DayOfWeek Monday = new(MondayKey, "Monday");
    public static readonly DayOfWeek Tuesday = new(TuesdayKey, "Tuesday");
    public static readonly DayOfWeek Wednesday = new(WednesdayKey, "Wednesday");
    public static readonly DayOfWeek Thursday = new(ThursdayKey, "Thursday");
    public static readonly DayOfWeek Friday = new(FridayKey, "Friday");
    public static readonly DayOfWeek Saturday = new(SaturdayKey, "Saturday");
    public static readonly DayOfWeek Sunday = new(SundayKey, "Sunday");

    public DayOfWeek(string key, string name) : base(key, name)
    {
    }

    public static DayOfWeek Create(string type)
    {
        return type switch
        {
            MondayKey => Monday,
            TuesdayKey => Tuesday,
            WednesdayKey => Wednesday,
            ThursdayKey => Thursday,
            FridayKey => Friday,
            SaturdayKey => Saturday,
            SundayKey => Sunday,
            _ => throw new InvalidOperationException($"Unsupported type '{type}'")
        };
    }

    public bool Equals(System.DayOfWeek dayOfWeek)
    {
        return dayOfWeek switch
        {
            System.DayOfWeek.Monday when Key == MondayKey => true,
            System.DayOfWeek.Tuesday when Key == TuesdayKey => true,
            System.DayOfWeek.Wednesday when Key == WednesdayKey => true,
            System.DayOfWeek.Thursday when Key == ThursdayKey => true,
            System.DayOfWeek.Friday when Key == FridayKey => true,
            System.DayOfWeek.Saturday when Key == SaturdayKey => true,
            System.DayOfWeek.Sunday when Key == SundayKey => true,
            
            _ => false
        };
    }
}