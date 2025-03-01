

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapPost("/webhook", async (HttpRequest request) =>
{
    using var reader = new StreamReader(request.Body);
    var payload = await reader.ReadToEndAsync();
    
    Console.WriteLine("Received GitHub webhook event:");
    Console.WriteLine(payload);

    return Results.Ok();
});

app.Run();
