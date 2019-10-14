using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebService_Meals.Models;

namespace WebService_Meals.Controllers
{
    [Authorize]
    public class MealController : Controller
    {
        private readonly IMealServiceRepository _repo;

        public MealController(IMealServiceRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var meals = _repo.GetAllMealOptions();
            var associatedDishes = new List<Tuple<int, IEnumerable<Dish>>>();
            foreach (Meal meal in meals)
            {
                var tuple = new Tuple<int, IEnumerable<Dish>>(meal.Id, _repo.GetAllDishesForMeal(meal));
            }
            ViewBag.AssociatedDishes = associatedDishes;
            
            return View(meals);
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


        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(CreateMealModel model)
        {
            if (ModelState.IsValid)
            {
                Dish starter = _repo.GetDish(model.StarterId);
                Dish main = _repo.GetDish(model.MainId);
                Dish dessert = _repo.GetDish(model.DessertId);
                Meal meal = new Meal(model.DateValid);

                _repo.CreateMeal(meal, new Dish[] { starter, main, dessert });
                return RedirectToAction("Index");
            }
            return View();
        }


        public IActionResult Detail(int Id)
        {
            var meal = _repo.GetMeal(Id);
            ViewBag.Dishes = _repo.GetAllDishesForMeal(meal);
            return View(meal);
        }

        public IActionResult Edit(int Id)
        {
            var meal = _repo.GetMeal(Id);
            return View(meal);
        }



    }
}
