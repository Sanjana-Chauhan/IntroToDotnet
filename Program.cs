using MyWebApp.Api.Data;
using MyWebApp.Api.Endpoints;
var builder = WebApplication.CreateBuilder(args);//builder to inject services and perform all services

builder.Services.AddEndpointsApiExplorer(); //add api-endpoints
builder.Services.AddSwaggerGen();

//Called as dependency injection Not a good practice to define connect str here so define it in appsettings
var connectStr=builder.Configuration.GetConnectionString("GameStoreDBConnect");
builder.Services.AddSqlite<GamestoreContext>(connectStr);

var app = builder.Build();  // provide the instance of the runniing service

if (app.Environment.IsDevelopment()) //Only for development to provide Swagger UI
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection(); //to redirect every http to https . not mandatory

app.mapGamesEndpoints();// for the endpoints of the server

app.MigrateDb();//defined by developer to perform auto migrations everytime.
app.Run();


