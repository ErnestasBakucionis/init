var builder = WebApplication.CreateBuilder(args);

var clientUrl = builder.Configuration["ClientUrl"];

if (string.IsNullOrEmpty(clientUrl))
{
    throw new InvalidOperationException("ClientUrl must be configured in the application settings.");
}

builder.Services.AddControllersWithViews();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", policy =>
    {
        policy.WithOrigins(clientUrl)
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseCors("AllowSpecificOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();
