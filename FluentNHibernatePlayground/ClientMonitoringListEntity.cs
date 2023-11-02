using Infrastructure.Seedwork.DataTypes;

namespace FluentNHibernatePlayground;

public class ClientMonitoringListEntity
{
    public virtual ClientMonitoringList Id { get; init; }

    public virtual string Name { get; set; } = null!;

    public virtual long PersonsCount { get; protected set; }

    public virtual UtcDateTime? LastUpdateDateTime { get; protected set; }

    public virtual IList<MonitoringListTransform>? Transforms { get; protected set; }

    public virtual void EditTransforms(IList<MonitoringListTransform>? transforms)
    {
        if (transforms is null)
        {
            Transforms.Clear();
            return;
        }

        Transforms = transforms;
    }
}