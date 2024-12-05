var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure Kestrel to listen on all IP addresses (0.0.0.0) and set port from environment (default: 8080)
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
app.Urls.Add($"http://0.0.0.0:{port}");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    // Enable Swagger in both Development and Production for easy testing
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Commented out HTTPS redirection for AKS/Docker as it may be handled externally
// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
