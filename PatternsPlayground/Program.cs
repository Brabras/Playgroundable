using PatternsPlayground.Weather_Observer_Behavior;

//
// #region Behavior-Strategy
//
// var mallardDuck = MallardDuck.CreateMallardDuck();
//
// mallardDuck.Quack();
// mallardDuck.Fly();
// mallardDuck.Display();
//
// mallardDuck.SetFlyBehavior(new ReactiveFlying());
//
// mallardDuck.Fly();
//
// #endregion

#region Behavior-Observer

var weatherData = new WeatherData();

var currentDataDisplay        = new CurrentStateDisplayObserver();
var statisticsDisplayObserver = new StatisticsDisplayObserver();
var futureDisplayObserver     = new FutureDisplayObserver();

weatherData.RegisterObserver(currentDataDisplay);
weatherData.RegisterObserver(statisticsDisplayObserver);
weatherData.RegisterObserver(futureDisplayObserver);

weatherData.MeasurementsChanged();
weatherData.MeasurementsChanged();
weatherData.MeasurementsChanged();


#endregion