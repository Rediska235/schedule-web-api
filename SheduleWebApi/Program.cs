using SheduleWebApi;
using Microsoft.EntityFrameworkCore;
using SheduleWebApi.Controllers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    string connection = builder.Configuration["ConnectionStrings:Default"];
    options.UseSqlServer(connection);
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// при любом запросе будет лог в консоль
app.Use(async (context, next) =>
{
    await next.Invoke();

    app.Logger.LogInformation($"request: {context.Request.Path + context.Request.QueryString}\n" +
                    $"      status: {context.Response.StatusCode}\n" +
                    $"      time: {DateTime.Now}\n");
});

app.Run();
