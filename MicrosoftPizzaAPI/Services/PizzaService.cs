using System;
using MicrosoftPizzaAPI.Models;

namespace MicrosoftPizzaAPI.Services
{
	public static class PizzaService
	{
		static List<Pizza> Pizzas { get; set; }
		static int nextId = 4;
		static PizzaService()
		{
			Pizzas = new List<Pizza>
			{
				//new Pizza(1, "Classic Italian", false),
				//new Pizza(2, "Veggie", true)
				new Pizza { Id = 1, Name = "Classic Italian", IsGlutenFree = false },
                new Pizza { Id = 2, Name = "Veggie", IsGlutenFree = true },
                new Pizza { Id = 3, Name = "String", IsGlutenFree = true }

            };
		}

		public static List<Pizza> GetAll() => Pizzas;

		public static Pizza? Get(int id) => Pizzas.FirstOrDefault(p => p.Id == id);

		public static void Add(Pizza pizza)
		{
			pizza.Id = nextId++; //changes the attribute of the new pizza object to the correct one (nextId) and increments it
			Pizzas.Add(pizza);
		}

		public static Pizza? Update(int id, Pizza pizza)
		{
            int index = Pizzas.FindIndex(p => p.Id == id);
			if (index == -1)
				return null;
			Pizzas[index] = pizza;
			return pizza;
		}

		public static void Delete(int id)
		{
			var pizza = Get(id);
			if (pizza is null)
				return;
			Pizzas.Remove(pizza);
		}


	}
}