using FluentNHibernatePlayground;
using Infrastructure.DataAccess;
using Microsoft.Extensions.Configuration;

HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();

var configurationBuilder = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json");

var configuration = configurationBuilder.Build();

ConnectionStringsManager.ReadFromConfiguration(configuration);

var sessionFactory = NhSessionFactory.Build();


await using var dbSession = DbSession.Bind(sessionFactory);
using (var transaction = dbSession.NhSession.BeginTransaction())
{
    var nhSession = dbSession.NhSession;
    var client    = await nhSession.GetAsync<Client>(2L);


    var wallet = client.Wallets.First(x => x.Id == 2);
    
    wallet.Value = "asd";
    
    await nhSession.SaveOrUpdateAsync(client);

    Console.ReadLine();

    // await nhSession.SaveOrUpdateAsync(wallet);
    
    Console.WriteLine("wallet.value = " + wallet.Value);
    
    Console.WriteLine("wallet.client.value = " + wallet.Client.Value);

    await transaction.CommitAsync();
}
