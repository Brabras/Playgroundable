namespace PatternsPlayground.Pizza_Fabric_Creating;

public abstract class PizzaStore
{
    protected IPizzaIngredientFactory IngredientFactory { get; init; } = null!;

    public Pizza OrderPizza(PizzaType type)
    {
        Pizza pizza = type switch
        {
            PizzaType.Cheese => new CheesePizza(IngredientFactory),
            PizzaType.Veggie => new VeggiePizza(IngredientFactory),
            PizzaType.Clam => new ClamPizza(IngredientFactory),
            _ => throw new NotImplementedException()
        };

        pizza.Prepare();
        pizza.Bake();
        pizza.Cut();
        pizza.Box();
        return pizza;
    }
    
    // public abstract Pizza CreatePizza(PizzaType type); - был бы Фабричным методом, но сейчас имеем Абстрактную фабрику IPizzaIngredientFactory
}

public sealed class NyPizzaStore: PizzaStore
{
    public NyPizzaStore()
    {
        IngredientFactory = new NyPizzaIngredientFactory();
    }
}

public sealed class ChicagoPizzaStore : PizzaStore
{
    public ChicagoPizzaStore()
    {
        IngredientFactory = new ChicagoPizzaIngredientFactory();
    }
}

public sealed class CaliforniaPizzaStore : PizzaStore
{
    public CaliforniaPizzaStore()
    {
        IngredientFactory = new CaliforniaPizzaIngredientFactory();
    }
}