using Microsoft.AspNetCore.Mvc;
using MicrosoftPizzaAPI.Services;
using MicrosoftPizzaAPI.Models;
using System;
using System.Reflection.Metadata.Ecma335;

namespace MicrosoftPizzaAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class PizzaController : ControllerBase
	{
		// GET all action
		[HttpGet]
		public ActionResult<List<Pizza>> GetAllPizzas() => PizzaService.GetAll();

		// GET by Id action
		[HttpGet("{id}")]
		public ActionResult<Pizza> GetPizzaById(int id) {
			var pizzaResponse = PizzaService.Get(id);
			if(pizzaResponse == null) 
				return NotFound();

            return Ok(pizzaResponse);
        }

		// POST action
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreatePizza(Pizza pizza)
		{
			if (pizza == null)
				return BadRequest();

			PizzaService.Add(pizza);
            return CreatedAtAction(nameof(GetPizzaById), new { id = pizza.Id }, pizza);
        }

		// PUT action
		[HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdatePizza(int id, Pizza pizza)
		{

			if(pizza.Id != id)
				return BadRequest();

			var pizzaTemp = PizzaService.Update(id, pizza);
			if(pizzaTemp == null)
				return NotFound();

            return Ok(pizzaTemp);
		}

		// DELETE action
		[HttpDelete("{id}")]
		public IActionResult DeletePizza(int id)
		{
			var deletedPizza = PizzaService.Get(id);
			if(deletedPizza == null)
				return NotFound();

			PizzaService.Delete(id);

			return Ok(deletedPizza);
		}

    }
}