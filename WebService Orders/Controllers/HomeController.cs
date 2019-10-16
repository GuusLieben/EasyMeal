using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using DomainModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Services;
using WebService_Orders.Models;

namespace WebService_Orders.Controllers
{
    public class HomeController : Controller
    {
        private readonly IReadOnlyRepository _repo;

        public HomeController(IReadOnlyRepository repository)
        {
            this._repo = repository;
        }

        public IActionResult Index()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Menu(int id)
        {
            var date = WeekMenuEM.StartOfWeek(DateTime.Today.Year, id);
            var firsteDateString = date.StartOfWeek(DayOfWeek.Monday).ToLongDateString();
            var lastDateString = date.AddDays(7).StartOfWeek(DayOfWeek.Sunday).ToLongDateString();
            var mealsForCurrentWeek = _repo.GetAllMealOptionsForWeek(date.Week(), date.Year).ToList();
            var mealsForCurrentWeekSorted = new SortedDictionary<DayOfWeek, List<Meal>>();

            mealsForCurrentWeek.ToList().ForEach(meal =>
            {
                if (mealsForCurrentWeekSorted.ContainsKey(meal.DateValid.DayOfWeek))
                {
                    mealsForCurrentWeekSorted.GetValueOrDefault(meal.DateValid.DayOfWeek).Add(meal);
                } else
                {
                    mealsForCurrentWeekSorted.Add(meal.DateValid.DayOfWeek, new List<Meal>() { meal });
                }
            });

            mealsForCurrentWeek = new List<Meal>();
            foreach (var sortedKey in mealsForCurrentWeekSorted)
            {
                sortedKey.Value.ForEach(m => {
                    mealsForCurrentWeek.Add(m);
                });
            }

            
            var dishesPerMeal = new Dictionary<int, IEnumerable<Dish>>();
            mealsForCurrentWeek.ToList().ForEach(meal =>
            {
                var dishes = _repo.GetAllDishesForMeal(meal);
                dishesPerMeal.Add(meal.Id, dishes);
            });

            // Collect current orders
            var dishesPresent = new Dictionary<int, Dish>();
            var orders = new List<ClientOrder>();
            if (TempData["Orders"] != null)
            {
                var orderTEMP = (string) TempData["Orders"];
                orders = ((JArray)JsonConvert.DeserializeObject(orderTEMP)).ToObject<List<ClientOrder>>();
                
                orders.ForEach(co => {
                    if (!dishesPresent.ContainsKey(co.DishId)) { 
                        dishesPresent.Add(co.DishId, _repo.GetDish(co.DishId));
                    }
                });
            }
            var orderJSON = JsonConvert.SerializeObject(orders);

            DayOfWeek[] days = new DayOfWeek[] { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday, DayOfWeek.Saturday, DayOfWeek.Sunday };
            var ordersByDay = new Dictionary<DayOfWeek, IEnumerable<ClientOrder>>();

            days.ToList().ForEach(day =>
            {
                ordersByDay.Add(day, orders.Where(co => co.Date.DayOfWeek.Equals(day)));
            });



            ViewBag.SortedOrders = ordersByDay;
            ViewBag.OrderedDishes = dishesPresent;
            
            ViewBag.WeekNumber = id.ToString();
            ViewBag.Year = date.Year;
            ViewBag.DateString = firsteDateString + " - " + lastDateString;
            ViewBag.DishesPerMeal = dishesPerMeal;
            ViewBag.Orders = orders;
            ViewBag.OrderIds = orderJSON;


            return View(mealsForCurrentWeek);
        }

        [HttpPost]
        public ActionResult Menu(int mealId, int week, string exOrders, DateTime orderDate, string DessertSize = "Medium", string StarterSize = "Medium", string MainSize = "Medium")
        {
            Debug.WriteLine("[POST] Reached POST");
            var previousOrders = ((JArray)JsonConvert.DeserializeObject(exOrders)).ToObject<List<ClientOrder>>();
            var meal = _repo.GetMeal(mealId);
            var dishes = _repo.GetAllDishesForMeal(meal);
            dishes.ToList().ForEach(md =>
            {
                Debug.WriteLine("[POST] Reached a MD " + md.Id);
                var Id = md.Id;
                DishSize size = DishSize.Medium;
                DishType currentType = md.DishType;
                if (currentType.Equals(DishType.Starter))
                {
                    size = (DishSize)Enum.Parse(typeof(DishSize), StarterSize);
                } else if (currentType.Equals(DishType.Main))
                {
                    size = (DishSize)Enum.Parse(typeof(DishSize), MainSize);
                }
                else if(currentType.Equals(DishType.Dessert))
                {
                    size = (DishSize)Enum.Parse(typeof(DishSize), DessertSize);
                }

                var singleOrder = new ClientOrder()
                {
                    DishId = Id,
                    Client = null,
                    Date = orderDate,
                    Size = size
                };
                Debug.WriteLine("[POST] Reached complete order " + singleOrder);
                previousOrders.Add(singleOrder);
            });

            Debug.WriteLine("[POST] Reached end of orders");
            String orderJSON = JsonConvert.SerializeObject(previousOrders);
            TempData["Orders"] = orderJSON;

            return RedirectToAction("Menu", week);
        }
    }
}
