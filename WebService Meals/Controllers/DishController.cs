using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebService_Meals.Controllers
{
    [Authorize]
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

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Delete(int Id)
        {
            _repo.DeleteDish(Id);
            return RedirectToAction("Index");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(Dish model)
        {
            if (ModelState.IsValid)
            {
                _repo.CreateDish(model);
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(Dish model)
        {
            if (ModelState.IsValid)
            {
                model.Price = model.Price / 100;
                _repo.EditDish(model);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}