var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Add CORS services
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins(
                "http://localhost:3000",
                "http://frontend:3000" // Docker service name
             )
             .AllowAnyMethod()
             .AllowAnyHeader()
             .AllowCredentials();
    });
});

builder.WebHost.UseUrls("http://0.0.0.0:5289");
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Clinic Scheduler API",
        Version = "v1",
        Description = "API for the Clinic Scheduling System",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Your Name",
            Email = "your.email@example.com"
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Clinic Scheduler API v1");
        c.RoutePrefix = string.Empty; // Makes Swagger UI available at the root URL
    });
}

// Add CORS middleware - THIS LINE WAS MISSING
app.UseCors("AllowFrontend");

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();