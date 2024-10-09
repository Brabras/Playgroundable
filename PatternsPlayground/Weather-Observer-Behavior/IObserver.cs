namespace PatternsPlayground.Weather_Observer_Behavior;

public interface IObserver
{
    void Update();
}

public interface IDisplay
{
    void Display();
}

public sealed class CurrentStateObserver : IObserver, IDisplay
{
    private float Temperature { get; set; }
    private float Humidity { get; set; }
    private float Pressure { get; set; }

    private WeatherData WeatherData { get; init; }
    
    public CurrentStateObserver(WeatherData weatherData)
    {
        WeatherData = weatherData;
        weatherData.RegisterObserver(this);
        Temperature = weatherData.Temperature;
        Humidity    = weatherData.Humidity;
        Pressure    = weatherData.Pressure;
    }

    public void Update()
    {
        Temperature = WeatherData.Temperature;
        Humidity    = WeatherData.Humidity;
        Pressure    = WeatherData.Pressure;
    }

    public void Display()
    {
        Console.WriteLine("Текущее состояние");
        Console.WriteLine($"Температура: {Temperature}");
        Console.WriteLine($"Влажность: {Humidity}");
        Console.WriteLine($"Давление: {Pressure}");
        Console.WriteLine();
    }
}

public sealed class StatisticsObserver : IObserver, IDisplay
{
    private WeatherData WeatherData { get; init; }
    
    private readonly List<float> _temperature = [];
    private readonly List<float> _humidity = [];
    private readonly List<float> _pressure = [];

    public StatisticsObserver(WeatherData weatherData)
    {
        WeatherData = weatherData;
        weatherData.RegisterObserver(this);
        _temperature.Add(WeatherData.Temperature);
        _humidity.Add(WeatherData.Humidity);
        _pressure.Add(WeatherData.Pressure);
    }
    public void Update()
    {
        _temperature.Add(WeatherData.Temperature);
        _humidity.Add(WeatherData.Humidity);
        _pressure.Add(WeatherData.Pressure);
    }

    public void Display()
    {
        Console.WriteLine("Средние показатели");
        Console.WriteLine($"Температура: {_temperature.Average():F1}");
        Console.WriteLine($"Влажность: {_humidity.Average():F1}");
        Console.WriteLine($"Давление: {_pressure.Average():F1}");
        Console.WriteLine();
    }
}


public sealed class FutureObserver : IObserver, IDisplay
{
    private readonly Random _random = new();

    public FutureObserver(WeatherData weatherData)
    {
        weatherData.RegisterObserver(this);
    }

    public void Update()
    {
        // smth
    }

    public void Display()
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

public sealed class HeatIndexDisplay : IObserver, IDisplay
{
    private float Temperature { get; set; }
    private float Humidity { get; set; }

    private WeatherData WeatherData { get; }
    
    public HeatIndexDisplay(WeatherData weatherData)
    {
        WeatherData = weatherData;
        weatherData.RegisterObserver(this);
        Temperature = WeatherData.Temperature;
        Humidity    = WeatherData.Humidity;
    }

    private float ComputeHeatIndex(float t, float rh)
    {
        float index = (float)((16.923 + (0.185212 * t) + (5.37941 * rh) - (0.100254 * t * rh) +
                               (0.00941695 * (t * t)) + (0.00728898 * (rh * rh)) +
                               (0.000345372 * (t * t * rh)) - (0.000814971 * (t * rh * rh)) +
                               (0.0000102102 * (t * t * rh * rh)) - (0.000038646 * (t * t * t)) + (0.0000291583 *
                                                                                                   (rh * rh * rh)) + (0.00000142721 * (t * t * t * rh)) +
                               (0.000000197483 * (t * rh * rh * rh)) - (0.0000000218429 * (t * t * t * rh * rh)) +
                               0.000000000843296 * (t * t * rh * rh * rh)) -
                              (0.0000000000481975 * (t * t * t * rh * rh * rh)));
        return index;
    }

    public void Update()
    {
        Temperature = WeatherData.Temperature;
        Humidity    = WeatherData.Humidity;
    }

    public void Display()
    {
            Console.WriteLine($"Heat index: {ComputeHeatIndex(t: Temperature, rh: Humidity)}");
    }
}