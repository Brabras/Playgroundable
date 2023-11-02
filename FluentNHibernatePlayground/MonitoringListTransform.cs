using CSharpFunctionalExtensions;
using JetBrains.Annotations;

namespace FluentNHibernatePlayground;

public enum ClientMonitoringList
{
    UN = 1,
    KR = 2,
    PT = 3,
    PLPD = 4
}

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public class MonitoringListTransform : Entity
{
    public virtual string Xslt { get; protected set; } = null!;

    protected MonitoringListTransform()
    {
    }

    public virtual void EditXslt(string xslt)
    {
        Xslt = xslt;
    }

    public static MonitoringListTransform Create(string xslt)
    {
        return new MonitoringListTransform
        {
            Xslt = xslt,
        };
    }
}