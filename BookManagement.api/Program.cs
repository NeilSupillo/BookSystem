//  3 06 0 mins

using BookManagement.api.Data;
using BookManagement.api.Endpoints;
var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("Book");

builder.Services.AddSqlite<BookContext>(connString);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", builder =>
    {
        builder.WithOrigins("http://localhost:5173")
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});


var app = builder.Build();

app.UseCors("AllowReactApp");

app.MapBooksEndpoints();

await app.MigrateDbAsync();

app.Run();

