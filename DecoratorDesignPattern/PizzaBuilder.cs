public class PizzaBuilder
{
    private IPizza _pizza = new PlainPizza();

    public PizzaBuilder AddCheese()
    {
        _pizza = new Cheese(_pizza);
        return this;
    }

    public PizzaBuilder AddPepperoni()
    {
        _pizza = new Pepperoni(_pizza);
        return this;
    }

    public IPizza Build() => _pizza;
}