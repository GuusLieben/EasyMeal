using EasyMeal.Core.Domain;
using EasyMeal.Core.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.IO;

namespace EasyMeal.Web.Meals.Controllers
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
        public IActionResult Create([Bind("Name,Description,DietRestrictions,Price,DishType")] Dish model, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    if (image.Length > 0)
                    {
                        using (var stream = new MemoryStream())
                        {
                            image.CopyTo(stream);
                            model.Image = stream.ToArray();
                        }
                    }
                }
                _repo.CreateDish(model);
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(Dish model, IFormFile image)
        {
            Debug.WriteLine("REACHED EDIT");
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    if (image.Length > 0)
                    {
                        using (var stream = new MemoryStream())
                        {
                            image.CopyTo(stream);
                            model.Image = stream.ToArray();
                        }
                    }
                }
                model.Price /= 100;
                _repo.EditDish(model);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}