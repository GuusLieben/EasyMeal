using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                        return Ok(_repo.GetAllMealOptionsForWeek(parsedDate.Week(), parsedDate.Year));
                    } else
                    {
                        return Ok(_repo.GetAllMealOptionsForDay(parsedDate));
                    }
                    
                }
            }
            return Ok(_repo.GetAllMealOptions());
        }

        [HttpGet("{id}")]
        public ActionResult<string> GetOne(int id)
        {
            return Ok(_repo.GetMeal(id));
        }

        [HttpPost]
        public void Post([FromBody] Meal dish)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Meal dish)
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