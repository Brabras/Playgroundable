namespace PatternsPlayground.Pizza_Fabric_Creating;

public interface IPizzaIngredientFactory
{
    public Dough CreateDough();
    public Sauce CreateSauce();
    public Cheese CreateCheese();
    public Veggie[] CreateVeggies();
    public Clams CreateClam();
}

public class NyPizzaIngredientFactory : IPizzaIngredientFactory
{
    public Dough CreateDough()
    {
        return new ThinDough();
    }
    
    public Sauce CreateSauce()
    {
        return new MarinaraSauce();
    }

    public Cheese CreateCheese()
    {
        return new ReggianoCheese();
    }

    public Veggie[] CreateVeggies()
    {
        return [new Tomato()];
    }

    public Clams CreateClam()
    {
        return new Shell();
    }
}


public class ChicagoPizzaIngredientFactory : IPizzaIngredientFactory
{
    public Dough CreateDough()
    {
        return new ThinDough();
    }
    
    public Sauce CreateSauce()
    {
        return new PineappleSauce();
    }

    public Cheese CreateCheese()
    {
        return new ChedderCheese();
    }

    public Veggie[] CreateVeggies()
    {
        return [new Tomato(), new Onion()];
    }

    public Clams CreateClam()
    {
        return new Shell();
    }
}


public class CaliforniaPizzaIngredientFactory : IPizzaIngredientFactory
{
    public Dough CreateDough()
    {
        return new ThickDough();
    }
    
    public Sauce CreateSauce()
    {
        return new MarinaraSauce();
    }

    public Cheese CreateCheese()
    {
        return new ChedderCheese();
    }

    public Veggie[] CreateVeggies()
    {
        return [new Tomato(), new Onion()];
    }

    public Clams CreateClam()
    {
        return new Crab();
    }
}