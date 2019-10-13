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
            return View(_repo.GetAllMealOptions());
        }

        public IActionResult Create()
        {
            List<Dish> starters = new List<Dish>();
            List<Dish> mains = new List<Dish>();
            List<Dish> desserts = new List<Dish>();
            foreach (Dish dish in _repo.GetAllDishes())
            {
                if (dish.DishType.Equals(DishType.Starter)) starters.Add(dish);
                else if (dish.DishType.Equals(DishType.Main)) mains.Add(dish);
                else if (dish.DishType.Equals(DishType.Dessert)) desserts.Add(dish);
            }
            ViewBag.Starters = starters;
            ViewBag.Mains = mains;
            ViewBag.Desserts = desserts;

            return View();
        }
    }
}
