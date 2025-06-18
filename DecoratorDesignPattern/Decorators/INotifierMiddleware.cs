using System.Threading.Tasks;

public delegate Task NotifierDelegate(string message);

public interface INotifierMiddleware
{
    Task InvokeAsync(string message, NotifierDelegate next);
}