using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebService_Meals.Controllers
{
    public class DishController : Controller
    {

        private readonly IMealServiceRepository _repo;

        public DishController(IMealServiceRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            
            return View(_repo.GetAllDishes());
        }

        public IActionResult Edit(int id)
        {
            Dish dish = _repo.GetDish(id);
            return View(dish);
        }

        public IActionResult Detail(int id)
        {
            Dish dish = _repo.GetDish(id);
            return View(dish);
        }
    }
}