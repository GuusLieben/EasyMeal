using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EasyMeal.Core.Domain;
using EasyMeal.Core.Domain.Services;
using System.Web.Http.Cors;

namespace EasyMeal.API.Controllers
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
        public ActionResult Post([FromBody] Dish dish)
        {
            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Dish dish)
        {
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return NoContent();
        }
    }
}
