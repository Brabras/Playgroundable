using FluentNHibernate.Mapping;

namespace FluentNHibernatePlayground.Mappings;

public class MonitoringListTransformMap : ClassMap<MonitoringListTransform>
{
    public MonitoringListTransformMap()
    {
        Schema("test");

        Id(x => x.Id);
        
        Map(x => x.TransformXslt);

        Map(x => x.IsActive);

        HasMany(x => x.Replacements)
            .Schema("test")
            .Table("monitoring_list_transform_replacements")
            .KeyColumn("monitoring_list_transform_id")
            .OrderBy("sort_order")
            .Cascade.AllDeleteOrphan();
        
        HasManyToMany(x => x.MonitoringLists)
            .Schema("test")
            .Table("lists_transforms")
            .ParentKeyColumn("transform_id")
            .ChildKeyColumn("monitoring_list_id");
    }
}