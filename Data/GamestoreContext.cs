using Microsoft.EntityFrameworkCore;
using MyWebApp.Api.Entities;

namespace MyWebApp.Api.Data;
 public class GamestoreContext (DbContextOptions<GamestoreContext> options):DbContext(options)
 {
    //Objects we need to map can be considered as tables
    public DbSet<Game> Games { get; set; }
    public DbSet<Genre> Genres { get; set; }

//It will modify the model according to our needs. Data Seeding==> Do this only for simple and static data that need not to change

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       modelBuilder.Entity<Genre>().HasData(
         new {Id=1,Name="Fighting"},
         new {Id=2,Name="Racing"},
         new {Id=3,Name="Adventure"},
         new {Id=4,Name="Strategy"},
         new {Id=5,Name="Sports"}
       );
    }

 }

 //After defining the context of the database i.e the table to use ,use builder in Porgram.cs to register the services.
 