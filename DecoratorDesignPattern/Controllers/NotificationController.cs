using Microsoft.AspNetCore.Mvc;

namespace DecoratorDesignPattern.Controllers
{
    [ApiController]
[Route("[controller]")]
public class NotificationController : ControllerBase
{
    private readonly NotifierPipelineBuilder _pipelineBuilder;
    private readonly EmailNotifier _emailNotifier;

    public NotificationController(NotifierPipelineBuilder pipelineBuilder, EmailNotifier emailNotifier)
    {
        _pipelineBuilder = pipelineBuilder;
        _emailNotifier = emailNotifier;
    }

    [HttpPost]
    public IActionResult Send(string message)
    {
        var pipeline = _pipelineBuilder
            .UseMiddleware<RetryMiddleware>()
            .UseMiddleware<AuditMiddleware>()
            .Build(_emailNotifier);

        pipeline(message);
        return Ok();
    }
}
}