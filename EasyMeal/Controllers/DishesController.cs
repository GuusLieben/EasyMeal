using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Services;
using Infrastructure.Meals;
using Microsoft.AspNetCore.Mvc;

namespace EasyMeal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishesController : ControllerBase
    {

        private readonly IMealServiceRepository _repo;

        public DishesController(IMealServiceRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> GetForMealOrDefault([FromQuery] int meal)
        {
            if (meal != 0) return Ok(_repo.GetAllDishesForMeal(meal));
            else return Ok(_repo.GetAllDishes());
        }

        [HttpGet("{id}")]
        public ActionResult<string> GetOne(int id)
        {
            return Ok(_repo.GetDish(id));
        }

        [HttpPost]
        public void Post([FromBody] Dish dish)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Dish dish)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
