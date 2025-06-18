using System;
using System.Threading.Tasks;

public class EmailNotifier
{
    public Task Send(string message)
    {
        Console.WriteLine($"[Email] {message}");
        return Task.CompletedTask;
    }
}