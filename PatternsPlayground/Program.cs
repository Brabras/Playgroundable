using PatternsPlayground.Coffee_Decorator_Behavior;
using PatternsPlayground.Ducks_Strategy_Behavior;
using PatternsPlayground.Pizza_Fabric_Creating;
using PatternsPlayground.Weather_Observer_Behavior;

// #region Ducks-Strategy-Behavior
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
//
// #region Behavior-Observer
//
// var weatherData = new WeatherData();
//
// var currentDataDisplay        = new CurrentStateObserver(weatherData);
// var statisticsDisplayObserver = new StatisticsObserver(weatherData);
// var futureDisplayObserver     = new FutureObserver(weatherData);
// var heatIndexObserver         = new HeatIndexDisplay(weatherData);
//
// currentDataDisplay.Display();
// statisticsDisplayObserver.Display();
// futureDisplayObserver.Display();
// heatIndexObserver.Display();
//
// weatherData.MeasurementsChanged();
//
// currentDataDisplay.Display();
// statisticsDisplayObserver.Display();
// futureDisplayObserver.Display();
// heatIndexObserver.Display();
//
// weatherData.MeasurementsChanged();
//
// currentDataDisplay.Display();
// statisticsDisplayObserver.Display();
// futureDisplayObserver.Display();
// heatIndexObserver.Display();
//
// weatherData.MeasurementsChanged();
//
// currentDataDisplay.Display();
// statisticsDisplayObserver.Display();
// futureDisplayObserver.Display();
// heatIndexObserver.Display();
//
// #endregion
//
#region Coffee

Beverage espresso = Espresso.Create(CupSize.Large);
Console.WriteLine(espresso.GetDescription() + " " + espresso.Cost()); // should be 3

Beverage darkRoast = DarkRoast.Create(CupSize.Middle);
darkRoast = Mocha.AddToBeverage(darkRoast);
darkRoast = Mocha.AddToBeverage(darkRoast);
darkRoast = Whip.AddToBeverage(darkRoast);
var drd = darkRoast.GetDescription();
var drc = darkRoast.Cost();
Console.WriteLine(drd + " " + drc); // should be 6 + .2 + .2 + .6 = 7

Beverage houseBlend = HouseBlend.Create(CupSize.Small);
houseBlend = Soy.AddToBeverage(houseBlend);
houseBlend = Mocha.AddToBeverage(houseBlend);
houseBlend = Whip.AddToBeverage(houseBlend);
Console.WriteLine(houseBlend.GetDescription() + " " + houseBlend.Cost()); // should be 2 + .2 + .1 + .3 = 2.6

#endregion

#region Pizza

var pizzaStore = new NyPizzaStore();

var pizza = pizzaStore.OrderPizza(PizzaType.Veggie);
Console.WriteLine(pizza.GetName());
#endregion

