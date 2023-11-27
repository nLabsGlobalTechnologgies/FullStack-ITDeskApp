using ITDeskServer.WebAPI.Context;
using ITDeskServer.WebAPI.Options;
using ITDeskServer.WebAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Jwt Konfig�rasyonu
builder.Services.Configure<Jwt>(builder.Configuration.GetSection("Jwt")); // options pattern
builder.Services.ConfigureOptions<JwtSetupOptions>();

// Servis Konfig�rasyonu: CORS (Cross-Origin Resource Sharing) politikas�n� yap�land�rma
builder.Services.AddCors(corsService =>
{
    corsService.AddDefaultPolicy(policy =>
    {
        // Herhangi bir ba�l�k ve metoda izin ver, kimlik bilgilerini de kabul et
        policy.AllowAnyHeader().AllowAnyMethod().AllowCredentials();
    });
});

// Servis ve Provider Ekleme
builder.Services.AddScoped<JwtProvider>();
builder.Services.AddScoped<AuthService>();

// Jwt Authentication Ekleme
builder.Services.AddAuthentication().AddJwtBearer();

// SqlServer Konfig�rasyonu
string? connectionString = builder.Configuration.GetConnectionString("SqlServer"); // appsettings.json'dan �ekelim
//string? connectionString = ContextConstant.ConnectionString; // Constants/ContextConstant.cs'te tutabiliriz
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Swagger Konfig�rasyonu
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

// Geli�tirme ortam�nda Swagger'� etkinle�tir
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware Kullan�m�: CORS politikas�n� uygulamaya ba�la
app.UseCors();

// Hata y�netimi middleware'i
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
