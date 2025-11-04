using Microsoft.AspNetCore.Mvc;
using SalesAppAPI.Models;

namespace SalesAppAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzasController : ControllerBase
{
    private static List<Pizza> Pizzas = new List<Pizza>
    {
        new Pizza { Id = 1, Name = "Margherita", IsGlutenFree = false },
        new Pizza { Id = 2, Name = "Pepperoni", IsGlutenFree = false },
        new Pizza { Id = 3, Name = "Hawaiian", IsGlutenFree = false },
        new Pizza { Id = 4, Name = "Vegetarian", IsGlutenFree = true },
        new Pizza { Id = 5, Name = "BBQ Chicken", IsGlutenFree = false }
    };

    [HttpGet]
    public IEnumerable<Pizza> Get()
    {
        return Pizzas;
    }

    [HttpGet("{id}")]
    public ActionResult<Pizza> Get(int id)
    {
        var pizza = Pizzas.FirstOrDefault(p => p.Id == id);
        if (pizza == null)
        {
            return NotFound();
        }
        return pizza;
    }

    [HttpPost]
    public ActionResult<Pizza> Post(Pizza pizza)
    {
        pizza.Id = Pizzas.Max(p => p.Id) + 1;
        Pizzas.Add(pizza);
        return CreatedAtAction(nameof(Get), new { id = pizza.Id }, pizza);
    }
}