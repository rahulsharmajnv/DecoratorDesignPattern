public abstract class ToppingDecorator : IPizza
{
    protected IPizza _pizza;
    public ToppingDecorator(IPizza pizza) { _pizza = pizza; }
    public abstract string GetDescription();
    public abstract double GetCost();
}

public class Cheese : ToppingDecorator
{
    public Cheese(IPizza pizza) : base(pizza) { }
    public override string GetDescription() => _pizza.GetDescription() + ", Cheese";
    public override double GetCost() => _pizza.GetCost() + 1.0;
}

public class Pepperoni : ToppingDecorator
{
    public Pepperoni(IPizza pizza) : base(pizza) { }
    public override string GetDescription() => _pizza.GetDescription() + ", Pepperoni";
    public override double GetCost() => _pizza.GetCost() + 1.5;
}