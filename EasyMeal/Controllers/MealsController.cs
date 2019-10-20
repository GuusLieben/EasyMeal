using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyMeal.API.Models;
using EasyMeal.Core.Domain;
using EasyMeal.Core.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasyMeal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealsController : ControllerBase
    {

        private readonly IMealServiceRepository _repo;

        public MealsController(IMealServiceRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> GetForMealOrDefault([FromQuery] string date, [FromQuery] Boolean week)
        {
            if (date != null) 
            { 
                DateTime parsedDate = DateTime.ParseExact(date, "ddMMyyyy", null); ;
                if (parsedDate != null)
                {
                    if (week)
                    {
                        return Ok(ConvertListToModel(_repo.GetAllMealOptionsForWeek(parsedDate.Week(), parsedDate.Year)));
                    } else
                    {
                        return Ok(ConvertListToModel(_repo.GetAllMealOptionsForDay(parsedDate)));
                    }
                    
                }
            }
            return Ok(ConvertListToModel(_repo.GetAllMealOptions()));
        }

        [HttpGet("{id}")]
        public ActionResult<string> GetOne(int id)
        {
            return Ok(ConvertToModel(_repo.GetMeal(id)));
        }

        [HttpPost]
        public ActionResult Post([FromBody] Meal meal)
        {
            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Meal meal)
        {
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return NoContent();
        }

        private MealModel ConvertToModel(Meal meal)
        {
            var model = new MealModel()
            {
                DateValid = meal.DateValid,
                Id = meal.Id
            };

            var dishIds = new List<int>();
            _repo.GetAllDishesForMeal(meal).ToList().ForEach(d => dishIds.Add(d.Id));

            model.Dishes = dishIds;

            return model;
        }

        private List<MealModel> ConvertListToModel(IEnumerable<Meal> meals)
        {
            var convertedList = new List<MealModel>();
            meals.ToList().ForEach(m => convertedList.Add(ConvertToModel(m)));
            return convertedList;
        }

    }
}