using CSharpFunctionalExtensions;
using FluentNHibernatePlayground;
using JetBrains.Annotations;

public enum ClientMonitoringList : long
{
    UnitedNations = 1,
    KyrgyzRepublic = 2,
    PFT = 3,
    PLPD = 4,
}

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public class MonitoringListTransform : Entity<long>
{
    public virtual string TransformXslt { get; protected set; } = null!;

    public virtual bool IsActive { get; protected set; }

    public virtual IList<MonitoringListTransformReplacement> Replacements { get; protected set; } = null!;

    public virtual IList<ClientMonitoringList> MonitoringLists { get; set; } = null!;

    protected MonitoringListTransform()
    {
    }

    public virtual void Edit(string transformXslt,
        IList<ClientMonitoringList> monitoringLists)
    {
        TransformXslt = transformXslt;
        MonitoringLists = monitoringLists;
    }

    public virtual void AddReplacement(string oldValue,
        string newValue,
        long sortOrder)
    {
        var replacement = MonitoringListTransformReplacement.Create(transform: this,
            oldValue: oldValue,
            newValue: newValue,
            sortOrder: sortOrder);
        Replacements.Add(replacement);
    }

    public virtual void DeleteReplacements()
    {
        Replacements = new List<MonitoringListTransformReplacement>();
    }

    public virtual void Select()
    {
        IsActive = true;
    }

    public virtual void UnSelect()
    {
        IsActive = false;
    }

    public static MonitoringListTransform Create(string transformXslt,
        IList<ClientMonitoringList> monitoringLists)
    {
        return new MonitoringListTransform
        {
            TransformXslt = transformXslt,
            IsActive = true,
            Replacements = new List<MonitoringListTransformReplacement>(),
            MonitoringLists = monitoringLists
        };
    }
}