using FluentNHibernate.Mapping;
using JetBrains.Annotations;

namespace FluentNHibernatePlayground.Mappings;

[UsedImplicitly]
public sealed class ClientMonitoringListEntityMap : ClassMap<ClientMonitoringListEntity>
{
    public ClientMonitoringListEntityMap()
    {
        Schema("test");

        Table("monitoring_lists");

        Id(x => x.Id)
            .CustomType<ClientMonitoringList>()
            .GeneratedBy.Assigned()
            .UnsavedValue("0");

        Map(x => x.Name);

        Map(x => x.PersonsCount);

        HasManyToMany(x => x.Transforms)
            .Schema("test")
            .Table("lists_transforms")
            .ParentKeyColumn("monitoring_list_id")
            .ChildKeyColumn("transform_id")
            .Cascade.SaveUpdate()
            .Not.Inverse();
    }
}