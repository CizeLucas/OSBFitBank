using Microsoft.OpenApi.Models;
using PizzaStore.DB;
using System;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options => { }); //Adding CORS

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Todo API", Description = "Keep track of your tasks", Version = "v1" });
    });
/*
Console.WriteLine(PizzaDB.GetPizza(1));
Console.WriteLine(new { Id = 1, Name = "Montemagno, Pizza shaped like a great mountain" });
Console.WriteLine("");
Console.WriteLine(typeof(PizzaDB.GetPizza(1)));
Console.WriteLine(typeof(new { Id = 1, Name = "Montemagno, Pizza shaped like a great mountain" }));
*/
var app = builder.Build();

/* ------------------------------------------------------------------- */
app.MapGet("/pizzas", () => PizzaDB.GetPizzas());

app.MapGet("/pizzas/{id}", (int id) => PizzaDB.GetPizza(id));

app.MapPost("/pizzas", (Pizza pizza) => PizzaDB.CreatePizza(pizza));

app.MapPut("/pizzas", (Pizza pizza) => PizzaDB.UpdatePizza(pizza));

app.MapDelete("/pizzas/{id}", (int id) => PizzaDB.RemovePizza(id));

/* ------------------------------------------------------------------- */

app.UseCors("Access-Control-Allow-Origin: *"); //Adding CORS String

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Todo API V1");
        });
}

app.Run();