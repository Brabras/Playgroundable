using FluentNHibernate.Mapping;
using JetBrains.Annotations;

namespace FluentNHibernatePlayground.Mappings;

[UsedImplicitly]
public sealed class MonitoringListTransformReplacementMap : ComponentMap<MonitoringListTransformReplacement>
{
    public MonitoringListTransformReplacementMap()
    {
        Map(x => x.Pattern);

        Map(x => x.Value);
    }
}