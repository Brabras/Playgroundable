using CSharpFunctionalExtensions;
using JetBrains.Annotations;

namespace FluentNHibernatePlayground;

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public class MonitoringListTransform : Entity
{
    public virtual string TransformXslt { get; protected set; } = null!;

    public virtual bool IsSelected { get; protected set; }

    public virtual IList<MonitoringListTransformReplacement> Replacements { get; protected set; } = null!;

    protected MonitoringListTransform()
    {
    }

    public virtual void EditXslt(string transformXslt)
    {
        TransformXslt = transformXslt;
    }

    public virtual void AddReplacement(string oldValue,
        string newValue,
        long sortOrder)
    {
        var replacement = MonitoringListTransformReplacement.Create(this, oldValue, newValue, sortOrder);
        Replacements.Add(replacement);
    }

    public virtual void Select()
    {
        IsSelected = true;
    }

    public virtual void UnSelect()
    {
        IsSelected = false;
    }

    public static MonitoringListTransform Create(string transformXslt)
    {
        return new MonitoringListTransform
        {
            TransformXslt = transformXslt,
            IsSelected = true,
            Replacements = new List<MonitoringListTransformReplacement>()
        };
    }
}