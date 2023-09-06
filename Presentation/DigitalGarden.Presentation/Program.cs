using DigitalGarden.Application;
using DigitalGarden.Domain;
using DigitalGarden.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BaseDigitalGardenContext, DigitalGardenContext>(a =>
{
    a.UseSqlServer(builder.Configuration.GetConnectionString("DigitalGardenConn"),
    s=>s.MigrationsAssembly("DigitalGarden.Presentation"));
}
);
builder.Services.AddMediatR(o => o.RegisterServicesFromAssembly(typeof(CreateGardener).Assembly));
builder.Services.AddControllers();
var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
