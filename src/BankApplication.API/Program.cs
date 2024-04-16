using BankApplication.API;
using BankApplication.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.UseControllerConfiguration();

builder.Services.AddEndpointsApiExplorer();

builder.Services.UseCorsConfiguration();

builder.Services.UseSwaggerConfiguration();

builder.Services.UseAutoMapperConfiguration();

builder.Services.UseDbContextConfiguration(builder);

builder.Services.UseDepencyInjectionConfiguration();

var app = builder.Build();

using var scope = app.Services.CreateScope();
await using var dbContext = scope.ServiceProvider.GetRequiredService<BankApplicationContext>();
await dbContext.Database.MigrateAsync();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UsePrometheusConfiguration();
}

app.UseSwagger();

app.UseSwaggerUI();

app.UseAppCorsConfiguration();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UsePrometheusConfiguration();

app.Run();
