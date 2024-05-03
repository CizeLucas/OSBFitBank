using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using PizzaStore.Context;
using PizzaStore.Models;

var builder = WebApplication.CreateBuilder(args);

//Configures the connection string (db file) (OBS: if it does not find a file named "Pizza", it will create one)
var connectionString = builder.Configuration.GetConnectionString("Pizzas") ?? "Data Source=Pizzas.db"; 

//For logging temporary data (InMemory): 
    //builder.Services.AddDbContext<PizzaDb>(options => options.UseInMemoryDatabase("items"));

//For logging persinstant Data (SQLite): 
    builder.Services.AddSqlite<PizzaDb>(connectionString);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "PizzaStore API",
        Description = "Making the Pizzas you love",
        Version = "v1"
    });
});

var app = builder.Build(); 

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "PizzaStore API V1");
    });
}

if(app.Environment.IsDevelopment())
    app.MapGet("/", () => "Hello World! See /pizza or /swagger for testing"); //route only accessable if the app is in development

app.MapGet("/pizza", async (PizzaDb db) => await db.Pizzas.ToListAsync());

app.MapPost("/pizza", async (PizzaDb db, Pizza pizza) => 
{
    await db.Pizzas.AddAsync(pizza);
    await db.SaveChangesAsync();
    return Results.Created($"/pizza/{pizza.Id}", pizza);
});

app.MapGet("/pizza/{id}", async (PizzaDb db, int id) => {
    Pizza? pizza = await db.Pizzas.FindAsync(id);
    if(pizza != null)
        return Results.Ok(pizza);
    else
        return Results.NoContent();
});

app.MapPut("/pizza/{id}", async (PizzaDb db, Pizza updatedPizza, int id) => {
    Pizza? pizza = await db.Pizzas.FindAsync(id);
    if(pizza == null) return Results.NoContent();
    pizza.Name = updatedPizza.Name;
    pizza.Description = updatedPizza.Description;  
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.MapDelete("/pizza/{id}", async (PizzaDb db, int id) => {
    Pizza? pizza = await db.Pizzas.FindAsync(id);
    if(pizza == null) return Results.NotFound();
    db.Pizzas.Remove(pizza);
    await db.SaveChangesAsync();
    return Results.Ok();
});

app.Run();
