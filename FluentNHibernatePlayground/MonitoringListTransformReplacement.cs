using CSharpFunctionalExtensions;
using JetBrains.Annotations;

namespace FluentNHibernatePlayground;

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public class MonitoringListTransformReplacement : Entity
{
    public virtual MonitoringListTransform MonitoringListTransform { get; protected init; } = null!;

    public virtual string OldValue { get; protected init; } = null!;

    public virtual string NewValue { get; protected init; } = null!;

    public virtual long SortOrder { get; protected init; }

    protected MonitoringListTransformReplacement()
    {
    }

    internal static MonitoringListTransformReplacement Create(MonitoringListTransform transform,
        string oldValue,
        string newValue,
        long sortOrder)
    {
        return new MonitoringListTransformReplacement
        {
            MonitoringListTransform = transform,
            OldValue = oldValue,
            NewValue = newValue,
            SortOrder = sortOrder
        };
    }
}