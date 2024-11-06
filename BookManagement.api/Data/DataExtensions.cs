using System;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.api.Data;
// file to run migrations on startup or dotnet run.
public static class DataExtensions
{
    public static void MigrateDb(this WebApplication app)
    {
        using var serviceScope = app.Services.CreateScope();
        var context = serviceScope.ServiceProvider.GetRequiredService<BookContext>();
        context.Database.Migrate();
    }
}
