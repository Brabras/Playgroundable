namespace PatternsPlayground.ChocolateBoiler_Singleton_Creating;

public class ChocolateBoiler
{
    private static volatile ChocolateBoiler? instance = new();

    public static ChocolateBoiler Instance
    {
        get
        {
            if (instance is null)
                throw new NullReferenceException();

            return instance;
        }
    }

    private bool _empty;
    private bool _boiled;

    private ChocolateBoiler()
    {
        _empty  = true;
        _boiled = false;
    }

    public void Fill()
    {
        if (!_empty)
            return;

        _empty  = false;
        _boiled = false;
    }

    public void Drain()
    {
        if (_empty || !_boiled)
            return;

        _empty  = true;
        _boiled = false;
    }

    public void Boil()
    {
        if (!_empty && !_boiled)
        {
            _boiled = true;
        }
    }
}