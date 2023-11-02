using JetBrains.Annotations;

namespace Infrastructure.Seedwork.DataTypes;

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public class CatalogObjectDTO
{
    public long Value { get; set; }

    public string Label { get; set; } = null!;
}