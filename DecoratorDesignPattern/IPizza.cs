public interface IPizza
{
    string GetDescription();
    double GetCost();
}

public class PlainPizza : IPizza
{
    public string GetDescription() => "Plain Pizza";
    public double GetCost() => 5.0;
}