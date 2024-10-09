using LoggingPlayground;
using Microsoft.Extensions.Configuration;
using Serilog;


var configurationBuilder = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json");

var configuration = configurationBuilder.Build();

Log.Logger = new LoggerBuilder().WithApplicationName("FinMonitoringPlayground").Build(configuration);

ConnectionStringsManager.ReadFromConfiguration(configuration);

for (int i = 0; i < 150; i++)
{
    Log.Logger.Information("Тестовый лог #{i}", i);
}

