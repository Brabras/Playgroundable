using PatternsPlayground.Coffee_Decorator_Behavior;
using PatternsPlayground.Ducks_Strategy_Behavior;
using PatternsPlayground.Weather_Observer_Behavior;


#region Ducks-Strategy-Behavior

var mallardDuck = MallardDuck.CreateMallardDuck();

mallardDuck.Quack();
mallardDuck.Fly();
mallardDuck.Display();

mallardDuck.SetFlyBehavior(new ReactiveFlying());

mallardDuck.Fly();

#endregion

#region Behavior-Observer

var weatherData = new WeatherData();

var currentDataDisplay        = new CurrentStateObserver(weatherData);
var statisticsDisplayObserver = new StatisticsObserver(weatherData);
var futureDisplayObserver     = new FutureObserver(weatherData);
var heatIndexObserver         = new HeatIndexDisplay(weatherData);

currentDataDisplay.Display();
statisticsDisplayObserver.Display();
futureDisplayObserver.Display();
heatIndexObserver.Display();

weatherData.MeasurementsChanged();

currentDataDisplay.Display();
statisticsDisplayObserver.Display();
futureDisplayObserver.Display();
heatIndexObserver.Display();

weatherData.MeasurementsChanged();

currentDataDisplay.Display();
statisticsDisplayObserver.Display();
futureDisplayObserver.Display();
heatIndexObserver.Display();

weatherData.MeasurementsChanged();

currentDataDisplay.Display();
statisticsDisplayObserver.Display();
futureDisplayObserver.Display();
heatIndexObserver.Display();

#endregion

#region MyRegion

var beverage = new HouseBlend("brabras");

Console.WriteLine(beverage.Description);

#endregion