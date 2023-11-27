using ITDeskServer.WebAPI.Context;
using ITDeskServer.WebAPI.Options;
using ITDeskServer.WebAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Jwt Konfigürasyonu
builder.Services.Configure<Jwt>(builder.Configuration.GetSection("Jwt")); // options pattern
builder.Services.ConfigureOptions<JwtSetupOptions>();

// Servis Konfigürasyonu: CORS (Cross-Origin Resource Sharing) politikasýný yapýlandýrma
builder.Services.AddCors(corsService =>
{
    corsService.AddDefaultPolicy(policy =>
    {
        // Herhangi bir baþlýk ve metoda izin ver, kimlik bilgilerini de kabul et
        policy.AllowAnyHeader().AllowAnyMethod().AllowCredentials();
    });
});

// Servis ve Provider Ekleme
builder.Services.AddScoped<JwtProvider>();
builder.Services.AddScoped<AuthService>();

// Jwt Authentication Ekleme
builder.Services.AddAuthentication().AddJwtBearer();

// SqlServer Konfigürasyonu
string? connectionString = builder.Configuration.GetConnectionString("SqlServer"); // appsettings.json'dan çekelim
//string? connectionString = ContextConstant.ConnectionString; // Constants/ContextConstant.cs'te tutabiliriz
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Swagger Konfigürasyonu
builder.Services.AddSwaggerGen(setup =>
{
    var jwtSecurityScheme = new OpenApiSecurityScheme
    {
        BearerFormat = "JWT",
        Name = "JWT Authentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

    setup.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { jwtSecurityScheme, Array.Empty<string>() }
    });
});

var app = builder.Build();

// Geliþtirme ortamýnda Swagger'ý etkinleþtir
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware Kullanýmý: CORS politikasýný uygulamaya baþla
app.UseCors();

// Hata yönetimi middleware'i
app.Use(async (context, next) =>
{
    try
    {
        await next(context);
    }
    catch (Exception ex)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = 500;
        await context.Response.WriteAsync(JsonConvert.SerializeObject(new { ErrorMessage = ex.Message }));
    }
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
