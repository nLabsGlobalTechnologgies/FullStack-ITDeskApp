var builder = WebApplication.CreateBuilder(args);

// Servis Konfigürasyonu: CORS (Cross-Origin Resource Sharing) politikasını yapılandırma
builder.Services.AddCors(corsService =>
{
    corsService.AddDefaultPolicy(policy =>
    {
        // Herhangi bir başlık ve metoda izin ver, kimlik bilgilerini de kabul et
        policy.AllowAnyHeader().AllowAnyMethod().AllowCredentials();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware Kullanımı: CORS politikasını uygulamaya başla
app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();