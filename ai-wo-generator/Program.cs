using ai_wo_generator.Services;
using ai_wo_generator.Services.OpenAIService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
//builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<IFitnessPlanService, FitnessPlanService>();
builder.Services.AddHttpClient<IOpenAIService, OpenAIService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.MapGet("/", () => "AI Powered WO Generator!");

app.Run();
