namespace PatternsPlayground.Weather_Observer_Behavior;

public interface ISubject
{
    void RegisterObserver(IDisplayObserver displayObserver);
    void UnregisterObserver(IDisplayObserver displayObserver);
    void NotifyObservers();
}