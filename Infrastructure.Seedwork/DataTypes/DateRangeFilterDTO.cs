namespace Infrastructure.Seedwork.DataTypes;

public class DateRangeFilterDTO
{
    public DateRangeType DateRangeType { get; set; } = null!;
    
    public Date? Date { get; set; } = null!;

    public UtcDateTime? StartDate { get; set; }

    public UtcDateTime? EndDate { get; set; }
}