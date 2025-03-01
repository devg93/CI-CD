

using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapPost("/webhook", async (HttpRequest request) =>
{
    using var reader = new StreamReader(request.Body);
    var payloadRaw = await reader.ReadToEndAsync();
    
    Console.WriteLine("Received GitHub webhook event:");
    Console.WriteLine(payloadRaw);

    // JSON პარსვა
    var data = JsonSerializer.Deserialize<GitHubPayload>(payloadRaw);
    if (data != null)
    {
        // მაგალითად, გამოვიტანოთ რომელ ბრენჩზე იყო push
        Console.WriteLine($"Ref: {data.@ref}");
    }

    return Results.Ok();
});

app.Run();
public class GitHubPayload
{
    public string? @ref { get; set; }
   
}