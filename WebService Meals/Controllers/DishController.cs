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
            Dish dish = _repo.GetDish(-2);
            return View(dish);
        }
    }
}