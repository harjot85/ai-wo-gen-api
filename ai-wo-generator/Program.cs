using ai_wo_generator.Data;
using ai_wo_generator.Repository;
using ai_wo_generator.Services.FitnessPlanService;
using ai_wo_generator.Services.OpenAIService;
using ai_wo_generator.Services.UserService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
//builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<IFitnessPlanService, FitnessPlanService>();
builder.Services.AddSingleton<DbConnectionFactory>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
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
