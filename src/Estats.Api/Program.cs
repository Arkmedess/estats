var builder = WebApplication.CreateBuilder(args);

// Adicionar suporte para OpenAPI/Swagger (Padrão .NET 9)
builder.Services.AddOpenApi();

var app = builder.Build();

// Configurar o pipeline de requisições HTTP
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// Endpoint básico de verificação de saúde do sistema (Health Check)
app.MapGet("/health", () => Results.Ok(new { Status = "Healthy", Timestamp = DateTime.UtcNow }));

app.Run();