using System.ComponentModel;

namespace SourceGeneratorsPlayground;

public partial class CarModel : INotifyPropertyChanged
{
    private double SpeedKmPerHourBackingField { get; set; }
    
    private int NumberOfDoorsBackingField { get; set; }

    private string ModelBackingField { get; set; } = "";

    public event PropertyChangedEventHandler? PropertyChanged;
}

public class Aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
{
}
