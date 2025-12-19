using DashboardApi.Application.Service;
using DashboardApi.Domain.Port;
using DashboardApi.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDashboardService, DashboardService>();
builder.Services.AddScoped<IEnergyClient, EnergyClient>();
builder.Services.AddScoped<ITransportClient, TransportClient>();
builder.Services.AddScoped<IWasteClient, WasteClient>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
