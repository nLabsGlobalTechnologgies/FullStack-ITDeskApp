var builder = WebApplication.CreateBuilder(args);

// Servis Konfig�rasyonu: CORS (Cross-Origin Resource Sharing) politikas�n� yap�land�rma
builder.Services.AddCors(corsService =>
{
    corsService.AddDefaultPolicy(policy =>
    {
        // Herhangi bir ba�l�k ve metoda izin ver, kimlik bilgilerini de kabul et
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

// Middleware Kullan�m�: CORS politikas�n� uygulamaya ba�la
app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();