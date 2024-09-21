namespace PatternsPlayground.Weather_Observer_Behavior;

public sealed class WeatherData : ISubject
{
    private readonly Random _random = new();

    private readonly List<IDisplayObserver> _observers = new();

    public void MeasurementsChanged()
    {
        NotifyObservers();
    }

    public void RegisterObserver(IDisplayObserver displayObserver)
    {
        _observers.Add(displayObserver);
    }

    public void UnregisterObserver(IDisplayObserver displayObserver)
    {
        _observers.Remove(displayObserver);
    }

    public void NotifyObservers()
    {
        var temp     = GetTemperature();
        var humidity = GetHumidity();
        var pressure = GetPressure();

        var data = WeatherInfo.Create(temp, humidity, pressure);
        foreach (var observer in _observers)
        {
            observer.Update(data);
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