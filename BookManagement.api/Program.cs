// 1 26 mins

using System.Reflection.Metadata.Ecma335;
using BookManagement.api.Dtos;
using BookManagement.api.Endpoints;
using BookManagement.api.Entities;
using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapBooksEndpoints();
app.Run();

