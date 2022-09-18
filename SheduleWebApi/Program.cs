using Microsoft.AspNetCore.Http.Extensions;
using SheduleWebApi;
using Microsoft.EntityFrameworkCore;
using SheduleWebApi.Controllers;
using SheduleWebApi.Logger;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    string connection = builder.Configuration["ConnectionStrings:Default"];
    options.UseSqlServer(connection);
});

// create fileLogger
ILoggerFactory fileLoggerFactory = LoggerFactory
    .Create(builder => builder.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "logger.txt")));
ILogger fileLogger = fileLoggerFactory.CreateLogger<Program>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Logging
int counter = 0;

app.Use(async (context, next) =>
{
    await next.Invoke();

    string currentTime = DateTime.Now.ToString();
    string request = context.Request.GetDisplayUrl() + context.Request.QueryString;
    string statusCode = context.Response.StatusCode.ToString();

    string logBody = "";

    counter++;
    if (counter == 1)
    {
        logBody += $"Start of the session: {currentTime}\n";
    }

    logBody += $"   Log {counter}\n" +
               $"       Time: {currentTime}\n" +
               $"       Request: {request}\n" +
               $"       StatusCode: {statusCode}\n";
    
    fileLogger.LogInformation(logBody);
});

app.Run();
