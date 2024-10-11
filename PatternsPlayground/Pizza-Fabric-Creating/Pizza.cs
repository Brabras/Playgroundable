namespace PatternsPlayground.Pizza_Fabric_Creating;

public abstract class Pizza
{
    protected string Name = null!;

    protected Dough Dough = null!;

    protected Sauce Sauce = null!;

    protected Cheese Cheese = null!;

    protected Veggie[]? Veggies;

    protected Clams? Clams;

    public abstract void Prepare();

    public void Bake()
    {
        Console.WriteLine("Bake");
    }

    public void Cut()
    {
        Console.WriteLine("Cut");
    }

    public void Box()
    {
        Console.WriteLine("Box");
    }

    public string GetName()
    {
        return Name;
    }
}

public enum PizzaType
{
    Cheese = 1,
    Veggie = 2,
    Clam = 3,
}

public sealed class CheesePizza : Pizza
{
    private IPizzaIngredientFactory _ingredientFactory;

    internal CheesePizza(IPizzaIngredientFactory ingredientFactory)
    {
        _ingredientFactory = ingredientFactory;
        Name               = "Cheese Pizza";
    }

    public override void Prepare()
    {
        Dough  = _ingredientFactory.CreateDough();
        Sauce  = _ingredientFactory.CreateSauce();
        Cheese = _ingredientFactory.CreateCheese();
    }
}

public sealed class VeggiePizza : Pizza
{
    private IPizzaIngredientFactory _ingredientFactory;

    internal VeggiePizza(IPizzaIngredientFactory ingredientFactory)
    {
        _ingredientFactory = ingredientFactory;
        Name               = "VeggiePizza Pizza";
    }

    public override void Prepare()
    {
        Dough   = _ingredientFactory.CreateDough();
        Sauce   = _ingredientFactory.CreateSauce();
        Cheese  = _ingredientFactory.CreateCheese();
        Veggies = _ingredientFactory.CreateVeggies();
    }
}

public sealed class ClamPizza : Pizza
{
    private IPizzaIngredientFactory _ingredientFactory;

    internal ClamPizza(IPizzaIngredientFactory ingredientFactory)
    {
        _ingredientFactory = ingredientFactory;
        Name               = "Clam Pizza";
    }

    public override void Prepare()
    {
        Dough  = _ingredientFactory.CreateDough();
        Sauce  = _ingredientFactory.CreateSauce();
        Cheese = _ingredientFactory.CreateCheese();
        Clams  = _ingredientFactory.CreateClam();
    }
}