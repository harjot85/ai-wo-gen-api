using ai_wo_generator.Data;
using ai_wo_generator.Models;
using ai_wo_generator.Repository.User;
using ai_wo_generator.Repository.UserStats;
using ai_wo_generator.Services;
using ai_wo_generator.Services.AuthService;
using ai_wo_generator.Services.FitnessPlanService;
using ai_wo_generator.Services.OpenAIService;
using ai_wo_generator.Services.UserService;
using ai_wo_generator.Services.UserStats;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
//builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSingleton<JwtService>();

builder.Services.Configure<JWTSettings>(builder.Configuration.GetSection("Jwt"));
builder.Services.Configure<SqlConnectionSettings>(builder.Configuration.GetSection("ConnectionStrings"));

var jwtSettings = builder.Configuration
    .GetSection("Jwt")
    .Get<JWTSettings>();

if (jwtSettings == null || string.IsNullOrWhiteSpace(jwtSettings.ApiKey))
{
    throw new InvalidOperationException(
        "JWT configuration is missing or invalid."
    );
}

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = true;
    options.SaveToken = true;

    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.ApiKey)),

        ValidateIssuer = true,
        ValidIssuer = jwtSettings.Issuer,
        
        ValidateAudience = true,
        ValidAudience = jwtSettings.Audience,
        
        ValidateLifetime = true,
        ClockSkew = TimeSpan.FromSeconds(30)
    };
});

builder.Services.AddAuthorization();

builder.Services.AddScoped<IFitnessPlanService, FitnessPlanService>();
builder.Services.AddSingleton<DbConnectionFactory>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserStatisticsRepository, UserStatisticsRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserStatisticsService, UserStatisticsService>();
builder.Services.AddHttpClient<IOpenAIService, OpenAIService>();
builder.Services.AddScoped<JwtService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Allow-AIWOG", policy =>
    {
        policy.WithOrigins("http://localhost:5173", "https://ai-wog-vite.vercel.app")
              .AllowAnyMethod()
              .AllowAnyHeader()
              .SetPreflightMaxAge(TimeSpan.FromHours(24));
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.UseCors("Allow-AIWOG");

app.MapControllers();

app.MapGet("/", () => "AI Powered WO Generator!");

app.Run();
