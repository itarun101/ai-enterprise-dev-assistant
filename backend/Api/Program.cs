using Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add HttpClient
builder.Services.AddHttpClient();

// Register AI Service
builder.Services.AddScoped<AIService>();

var app = builder.Build();

app.MapPost("/analyze", async (AIService aiService, string input) =>
{
    var result = await aiService.AnalyzeInputAsync(input);
    return Results.Ok(result);
});


app.Run();

