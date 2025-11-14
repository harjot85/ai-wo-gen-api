using ai_wo_generator.Services;
using ai_wo_generator.Services.OpenAIService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IFitnessPlanService, FitnessPlanService>();
//builder.Services.AddScoped<IOpenAIService, OpenAIService>();
builder.Services.AddHttpClient<IOpenAIService, OpenAIService>();

var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";
builder.WebHost.UseUrls($"http://*:{port}");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{   
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseHttpsRedirection();
}

app.UseAuthorization();

app.MapControllers();

app.MapGet("/", () => "AI Powered WO Generator!");

app.Run();
