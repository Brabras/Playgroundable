namespace PatternsPlayground.Weather_Observer_Behavior;

public sealed class WeatherData : ISubject
{
    private readonly Random _random = new();

    private readonly List<IObserver> _observers = new();

    public float Temperature { get; private set; }
    public float Humidity { get; private set; }
    public float Pressure { get; private set; }

    public WeatherData()
    {
        Temperature = GetTemperature();
        Humidity    = GetHumidity();
        Pressure    = GetPressure();
    }

    public void MeasurementsChanged()
    {
        Temperature = GetTemperature();
        Humidity    = GetHumidity();
        Pressure    = GetPressure();

        NotifyObservers();
    }

    public void RegisterObserver(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void UnregisterObserver(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in _observers)
        {
            observer.Update();
        }
    }

    private float GetTemperature()
    {
        return _random.Next(-20, 51);
    }

    private float GetHumidity()
    {
        return _random.Next(0, 101);
    }

    private float GetPressure()
    {
        return _random.Next(641, 817);
    }
}