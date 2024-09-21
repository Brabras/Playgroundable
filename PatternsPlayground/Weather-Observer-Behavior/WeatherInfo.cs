namespace PatternsPlayground.Weather_Observer_Behavior;

public sealed class WeatherInfo
{
    public float Temperature { get; private set; }
    public float Humidity { get; private set; }
    public float Pressure { get; private set; }

    private WeatherInfo()
    {
    }

    public static WeatherInfo Create(float temperature, float humidity, float pressure)
    {
        return new WeatherInfo()
        {
            Temperature = temperature,
            Humidity    = humidity,
            Pressure    = pressure
        };
    }
}