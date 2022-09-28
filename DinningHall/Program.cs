using DinningHall.Data;
using DinningHall.Services;

var builder = WebApplication.CreateBuilder(args);

var loggerFactory = LoggerFactory
            .Create(builder =>
            {
                builder.ClearProviders();
                builder.AddConsole();
            });

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<Menu>();
builder.Services.AddSingleton<IDinningHallService, DinningHallService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

using (var serviceScope = app.Services.CreateScope())
{
    var services = serviceScope.ServiceProvider;
    var _ = services.GetRequiredService<IDinningHallService>();
}

app.Run();
