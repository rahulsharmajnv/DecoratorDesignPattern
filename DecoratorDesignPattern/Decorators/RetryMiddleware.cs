using System;
using System.Threading.Tasks;

public class RetryMiddleware : INotifierMiddleware
{
    public async Task InvokeAsync(string message, NotifierDelegate next)
    {
        try
        {
            Console.WriteLine("[Retry] Attempting send...");
            await next(message);
        }
        catch
        {
            Console.WriteLine("[Retry] Retry after failure...");
            await next(message);
        }
    }
}