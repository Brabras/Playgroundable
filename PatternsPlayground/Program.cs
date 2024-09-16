using PatternsPlayground.Ducks;

Console.WriteLine("Hello, World!");

var mallardDuck = MallardDuck.CreateMallardDuck();

mallardDuck.Quack();
mallardDuck.Fly();
mallardDuck.Display();

mallardDuck.SetFlyBehavior(new ReactiveFlying());

mallardDuck.Fly();