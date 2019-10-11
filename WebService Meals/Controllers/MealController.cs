using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebService_Meals.Controllers
{
    public class MealController : Controller
    {
        private readonly IMealServiceRepository _repo;

        public MealController(IMealServiceRepository repo)
        {
            _repo = repo;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            Meal meal = _repo.GetMeal(-5);
            return View(meal);
        }
    }
}
