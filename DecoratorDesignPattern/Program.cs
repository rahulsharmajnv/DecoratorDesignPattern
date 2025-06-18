var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<EmailNotifier>();
builder.Services.AddTransient<NotifierPipelineBuilder>();
builder.Services.AddTransient<AuditMiddleware>();
builder.Services.AddTransient<RetryMiddleware>();
builder.Services.AddTransient<PizzaBuilder>();
builder.Services.AddTransient<PlainPizza>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Notification}/{action=Send}/{id?}");
    endpoints.MapControllers();
});


app.Run();

