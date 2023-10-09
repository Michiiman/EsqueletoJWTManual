using Microsoft.EntityFrameworkCore;
using Persistence;
using ApiEscuela.Extensions;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAplicacionServices();
builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());
builder.Services.AddSwaggerGen();
builder.Services.ConfigureCors();

builder.Services.AddDbContext<ApiEscuelaContext>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString("ConexMysql");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
	var services = scope.ServiceProvider;
	var loggerFactory = services.GetRequiredService<ILoggerFactory>();
	try
	{
		var context = services.GetRequiredService<ApiEscuelaContext>();
		await context.Database.MigrateAsync();
		await ApiEscuelaContextSeed.SeedRolesAsync(context,loggerFactory);
		await ApiEscuelaContextSeed.SeedAsync(context,loggerFactory);
	}
	catch (Exception ex)
	{
		var _logger = loggerFactory.CreateLogger<Program>();
		_logger.LogError(ex, "Ocurrio un error durante la migracion");
	}
}


app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

