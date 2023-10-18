using FluentNHibernate.Mapping;

namespace FluentNHibernatePlayground.Mappings;

public class MonitoringListTransformReplacementMap : ClassMap<MonitoringListTransformReplacement>
{
    public MonitoringListTransformReplacementMap()
    {
        Schema("test");

        Id(x => x.Id);

        References(x => x.MonitoringListTransform);

        Map(x => x.OldValue);

        Map(x => x.NewValue);

        Map(x => x.SortOrder);
    }
}