//  2 49 00 mins

using BookManagement.api.Data;
using BookManagement.api.Endpoints;
var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("Book");

builder.Services.AddSqlite<BookContext>(connString);

var app = builder.Build();

app.MapBooksEndpoints();

app.MigrateDb();

app.Run();

