using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Son.Models;

var builder = WebApplication.CreateBuilder(args);

// DbContext yapılandırması
builder.Services.AddDbContext<SonDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSqlConnection")));

var app = builder.Build();

// Database migration'larını otomatik uygula
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<SonDbContext>();
    dbContext.Database.Migrate();
}

app.MapGet("/", () => "Hello World!");

app.MapGet("/hello", async (SonDbContext dbContext) =>
{
    var greeting = await dbContext.Greetings.FirstOrDefaultAsync();
    return greeting != null ? greeting.Message : "Hello World!";
});

app.Run();