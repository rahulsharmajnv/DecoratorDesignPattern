using System;
using System.Collections.Generic;
using System.Linq;

public class NotifierPipelineBuilder
{
    private readonly IServiceProvider _provider;
    private readonly IList<Func<NotifierDelegate, NotifierDelegate>> _components = new List<Func<NotifierDelegate, NotifierDelegate>>();

    public NotifierPipelineBuilder(IServiceProvider provider)
    {
        _provider = provider;
    }

    public NotifierPipelineBuilder UseMiddleware<T>() where T : INotifierMiddleware
    {
        _components.Add(next =>
        {
            var middleware = (INotifierMiddleware)_provider.GetRequiredService(typeof(T));
            return msg => middleware.InvokeAsync(msg, next);
        });

        return this;
    }

    public NotifierDelegate Build(EmailNotifier finalNotifier)
    {
        NotifierDelegate pipeline = msg => finalNotifier.Send(msg);

        foreach (var component in _components.Reverse())
        {
            pipeline = component(pipeline);
        }

        return pipeline;
    }
}