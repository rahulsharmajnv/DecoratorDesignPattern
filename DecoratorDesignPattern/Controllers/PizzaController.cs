using Microsoft.AspNetCore.Mvc;
namespace DecoratorDesignPattern.Controllers{
[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
    [HttpPost]
    public IActionResult OrderPizza([FromBody] PizzaOrderRequest request)
    {
        var builder = new PizzaBuilder();
        if (request.Cheese) builder.AddCheese();
        if (request.Pepperoni) builder.AddPepperoni();
        var pizza = builder.Build();

        return Ok(new { Description = pizza.GetDescription(), Cost = pizza.GetCost() });
    }
}

public class PizzaOrderRequest
{
    public bool Cheese { get; set; }
    public bool Pepperoni { get; set; }
}
}