using System;
using System.Threading.Tasks;

public class AuditMiddleware : INotifierMiddleware
{
    public async Task InvokeAsync(string message, NotifierDelegate next)
    {
        Console.WriteLine("[Audit] Before sending...");
        await next(message);
        Console.WriteLine("[Audit] After sending...");
    }
}