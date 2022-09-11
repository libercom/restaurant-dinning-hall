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
//builder.Services.AddSingleton<IHostedService, TestServiceB>();
builder.Services.AddSingleton<IHostedService, TestService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
