namespace AutofacPlaygroundable;

public class NewMonitoringMatchEvent : DomainEvent.DomainEvent
{
    public long Match { get; }


    public DateTime Now { get; }

    public NewMonitoringMatchEvent(long match, DateTime now)
    {
        Match = match;
        Now = now;
    }
}