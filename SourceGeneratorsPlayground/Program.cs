using System.ComponentModel;
using SourceGeneratorsPlayground;

var car = new CarModel();

car.PropertyChanged += PropertyChanged;
car.SpeedKmPerHour  =  5;
car.SpeedKmPerHour  =  7;

void PropertyChanged(object? sender, PropertyChangedEventArgs e)
{
    Console.WriteLine("A property has changed: " + e.PropertyName);
}