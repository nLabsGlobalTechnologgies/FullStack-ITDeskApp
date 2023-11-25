var builder = WebApplication.CreateBuilder(args);

// Servis Konfigürasyonu: CORS (Cross-Origin Resource Sharing) politikasýný yapýlandýrma
builder.Services.AddCors(corsService =>
{
    corsService.AddDefaultPolicy(policy =>
    {
        // Herhangi bir baþlýk ve metoda izin ver, kimlik bilgilerini de kabul et
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

// Middleware Kullanýmý: CORS politikasýný uygulamaya baþla
app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();