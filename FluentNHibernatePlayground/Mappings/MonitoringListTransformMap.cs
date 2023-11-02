using FluentNHibernate.Mapping;
using JetBrains.Annotations;

namespace FluentNHibernatePlayground.Mappings;

[UsedImplicitly]
public sealed class MonitoringListTransformMap : ClassMap<MonitoringListTransform>
{
    public MonitoringListTransformMap()
    {
        Schema("test");

        Id(x => x.Id);
        
        Map(x => x.Xslt);
    }
}