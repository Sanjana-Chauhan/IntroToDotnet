using Microsoft.EntityFrameworkCore;

namespace MyWebApp.Api.Data;
public static class DataExtensions{
    public static void MigrateDb(this WebApplication app){
        using var scope=app.Services.CreateScope();
        //This scope gives an instance to access to the added or registered sqlite services

        var dbContext=scope.ServiceProvider.GetRequiredService<GamestoreContext>();
        dbContext.Database.Migrate();

    }
}