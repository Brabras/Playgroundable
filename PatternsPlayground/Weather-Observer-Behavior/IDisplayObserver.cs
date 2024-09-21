namespace PatternsPlayground.Weather_Observer_Behavior;

public interface IDisplayObserver
{
    void Update(WeatherInfo info);
}

public sealed class CurrentStateDisplayObserver : IDisplayObserver
{
    public void Update(WeatherInfo info)
    {
        Console.WriteLine("Текущее состояние");
        Console.WriteLine($"Температура: {info.Temperature}");
        Console.WriteLine($"Влажность: {info.Humidity}");
        Console.WriteLine($"Давление: {info.Pressure}");
        Console.WriteLine();
    }
}

public sealed class StatisticsDisplayObserver : IDisplayObserver
{
    private readonly List<WeatherInfo> WeatherInfos = [];

    public void Update(WeatherInfo info)
    {
        WeatherInfos.Add(info);

        var averages = GetAverageInfo();

        Console.WriteLine("Средние показатели");
        Console.WriteLine($"Температура: {averages.Temperature}");
        Console.WriteLine($"Влажность: {averages.Humidity}");
        Console.WriteLine($"Давление: {averages.Pressure}");
        Console.WriteLine();
    }

    private WeatherInfo GetAverageInfo()
    {
        var averageTemp     = WeatherInfos.Average(x => x.Temperature);
        var averageHumidity = WeatherInfos.Average(x => x.Humidity);
        var averagePressure = WeatherInfos.Average(x => x.Pressure);

        return WeatherInfo.Create(temperature: averageTemp,
                                  humidity: averageHumidity,
                                  pressure: averagePressure);
    }
}

public sealed class FutureDisplayObserver : IDisplayObserver
{
    private readonly Random _random = new();

    public void Update(WeatherInfo info)
    {
        var rnd = _random.Next(1, 4);

        var result = rnd switch
        {
            1 => "Будет снег",
            2 => "Будет дождь",
            3 => "Будет солнечно",
            _ => string.Empty
        };

        Console.WriteLine(result);
        Console.WriteLine();
    }
}