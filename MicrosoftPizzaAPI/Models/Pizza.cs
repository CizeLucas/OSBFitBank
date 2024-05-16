using System;

namespace MicrosoftPizzaAPI.Models
{
	public class Pizza
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public bool IsGlutenFree { get; set; }

		/*public Pizza(int id, string? name, bool IsGlutenFree)
		{
			Id = id;
			Name = name;
			IsGlutenFree = this.IsGlutenFree;
		}*/


	}
}