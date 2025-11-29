using ai_wo_generator.Data;
using ai_wo_generator.Repository.User;
using ai_wo_generator.Repository.UserStats;
using ai_wo_generator.Services.FitnessPlanService;
using ai_wo_generator.Services.OpenAIService;
using ai_wo_generator.Services.UserService;
using ai_wo_generator.Services.UserStats;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
//builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<IFitnessPlanService, FitnessPlanService>();
builder.Services.AddSingleton<DbConnectionFactory>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserStatisticsRepository, UserStatisticsRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserStatisticsService, UserStatisticsService>();
builder.Services.AddHttpClient<IOpenAIService, OpenAIService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Allow-AIWOG", policy =>
    {
        policy.WithOrigins("http://localhost:5173", "https://ai-wog-vite.vercel.app")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.UseCors("Allow-AIWOG");

app.MapControllers();

app.MapGet("/", () => "AI Powered WO Generator!");

app.Run();
