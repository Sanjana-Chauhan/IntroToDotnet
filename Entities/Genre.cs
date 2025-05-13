namespace MyWebApp.Api.Entities;
public class Genre
    {
        public int Id { get; set; }

        //need a default value  or else can be declared as nullable or required
        public required string Name { get; set; } = string.Empty;
    }
