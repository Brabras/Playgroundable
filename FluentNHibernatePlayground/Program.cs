using FluentNHibernatePlayground;
using Infrastructure.DataAccess;
using Microsoft.Extensions.Configuration;
using NHibernate.Linq;

HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();

var configurationBuilder = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json");

var configuration = configurationBuilder.Build();

ConnectionStringsManager.ReadFromConfiguration(configuration);

var sessionFactory = NhSessionFactory.Build();


long? nextId;
await using (var dbSession = DbSession.Bind(sessionFactory))
using (var transaction = dbSession.NhSession.BeginTransaction())
{
    var nhSession = DbSession.CurrentNhSession;

    var newTransform = MonitoringListTransform.Create("xslt-test2-value");
    var oldTransforms = await nhSession.Query<MonitoringListTransform>().ToListAsync();

    var unList = await nhSession.GetAsync<ClientMonitoringListEntity>(ClientMonitoringList.KR);

    oldTransforms.Add(newTransform);
    unList.EditTransforms(null);

    await nhSession.SaveOrUpdateAsync(unList);
    await nhSession.FlushAsync();
    nextId = newTransform.Id;

    await transaction.CommitAsync();
}

await using (DbSession.Bind(sessionFactory))
{
    var nhSession = DbSession.CurrentNhSession;

    var entity = await nhSession.GetAsync<ClientMonitoringListEntity>(ClientMonitoringList.UN);

    foreach (var transform in entity.Transforms!)
    {
        Console.WriteLine("Id: " + transform.Id);
        Console.WriteLine("XSLT: " + transform.Xslt);
    }
}