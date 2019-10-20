using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using EasyMeal.Core.Domain;
using EasyMeal.Core.Domain.Services;
using EasyMeal.Web.Orders.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Extensions = EasyMeal.Core.Domain.Extensions;

namespace EasyMeal.Web.Orders.Controllers
{

    [Authorize]
    public class PublicController : Controller
    {
        private readonly IReadOnlyRepository _mealRepo;
        private readonly IOrderRepository _orderRepo;

        public PublicController(IReadOnlyRepository mealRepository, IOrderRepository orderRepository)
        {
            this._mealRepo = mealRepository;
            this._orderRepo = orderRepository;
        }

        public IActionResult Index()
        {
            ViewBag.Client = Startup.UserManager.FindByNameAsync(User.Identity.Name).Result;
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Menu(int id)
        {
            var date = Extensions.StartOfWeek(DateTime.Today.Year, id);
            var firsteDateString = date.StartOfWeek(DayOfWeek.Monday).ToLongDateString();
            var lastDateString = date.AddDays(7).StartOfWeek(DayOfWeek.Sunday).ToLongDateString();
            var mealsForCurrentWeek = _mealRepo.GetAllMealOptionsForWeek(date.Week(), date.Year).ToList();
            var mealsForCurrentWeekSorted = new SortedDictionary<DayOfWeek, List<Meal>>();

            mealsForCurrentWeek.ToList().ForEach(meal =>
            {
                if (mealsForCurrentWeekSorted.ContainsKey(meal.DateValid.DayOfWeek))
                {
                    mealsForCurrentWeekSorted.GetValueOrDefault(meal.DateValid.DayOfWeek).Add(meal);
                }
                else
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
                var dishes = _mealRepo.GetAllDishesForMeal(meal);
                dishesPerMeal.Add(meal.Id, dishes);
            });

            // Collect current orders
            var dishesPresent = new Dictionary<int, Dish>();
            var orders = new List<ClientOrder>();
            if (TempData["Orders"] != null)
            {
                var orderTEMP = (string)TempData["Orders"];
                orders = ((JArray)JsonConvert.DeserializeObject(orderTEMP)).ToObject<List<ClientOrder>>();

                orders.ForEach(co => {
                    if (!dishesPresent.ContainsKey(co.DishId))
                    {
                        dishesPresent.Add(co.DishId, _mealRepo.GetDish(co.DishId));
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

            var client = Startup.UserManager.FindByEmailAsync(User.Identity.Name).Result;
            int ordersThisMonth = _orderRepo.GetOrdersForClientForMonth(client.Id, date.Month, date.Year).Count();

            ViewBag.SortedOrders = ordersByDay;
            ViewBag.OrderedDishes = dishesPresent;
            ViewBag.ordersThisMonth = ordersThisMonth;

            ViewBag.WeekNumber = id.ToString();
            ViewBag.Year = date.Year;
            ViewBag.DateString = firsteDateString + " - " + lastDateString;
            ViewBag.DishesPerMeal = dishesPerMeal;
            ViewBag.Orders = orders;
            ViewBag.OrderIds = orderJSON;
            ViewBag.DaysOfWeek = Enum.GetValues(typeof(DayOfWeek));

            return View(mealsForCurrentWeek);
        }

        [HttpPost]
        public ActionResult Menu(int mealId, int week, string exOrders, DateTime orderDate, Boolean dessert, Boolean starter, string DessertSize = "Medium", string StarterSize = "Medium", string MainSize = "Medium", string checkout = "false")
        {
            var previousOrders = ((JArray)JsonConvert.DeserializeObject(exOrders)).ToObject<List<ClientOrder>>();

            Debug.WriteLine("Dessert : " + dessert);
            Debug.WriteLine("Starter : " + starter);

            if (!checkout.Equals("true"))
            {
                var meal = _mealRepo.GetMeal(mealId);
                var dishes = _mealRepo.GetAllDishesForMeal(meal);

                dishes.ToList().ForEach(md =>
                {
                    var Id = md.Id;
                    DishSize size = DishSize.Medium;
                    DishType currentType = md.DishType;
                    if (currentType.Equals(DishType.Starter))
                    {
                        size = (DishSize)Enum.Parse(typeof(DishSize), StarterSize);
                    }
                    else if (currentType.Equals(DishType.Main))
                    {
                        size = (DishSize)Enum.Parse(typeof(DishSize), MainSize);
                    }
                    else if (currentType.Equals(DishType.Dessert))
                    {
                        size = (DishSize)Enum.Parse(typeof(DishSize), DessertSize);
                    }

                    var clientId = Startup.UserManager.FindByEmailAsync(User.Identity.Name).Result.Id;

                    int ordersThisMonth = _orderRepo.GetOrdersForClientForMonth(clientId, orderDate.Month, orderDate.Year).Count();
                    ViewBag.ordersThisMonth = ordersThisMonth + previousOrders.Count;

                    var singleOrder = new ClientOrder()
                    {
                        DishId = Id,
                        ClientId = clientId,
                        Date = orderDate,
                        Size = size
                    };
                    if ((md.DishType.Equals(DishType.Starter) && starter) || (md.DishType.Equals(DishType.Main)) || (md.DishType.Equals(DishType.Dessert) && dessert))
                    {
                        previousOrders.Add(singleOrder);
                    }
                });
            }

            String orderJSON = JsonConvert.SerializeObject(previousOrders);
            TempData["Orders"] = orderJSON;

            if (checkout.Equals("true"))
            {
                TempData["WeekNumber"] = week;
                return RedirectToAction("CheckedOut", "Public", week);
            }
            else
            {
                return RedirectToAction("Menu", "Public", week);
            }
        }

        public IActionResult CheckedOut(int id)
        {
            if (id == 0 && TempData["WeekNumber"] != null) id = (int)TempData["WeekNumber"];

            var dishesPresent = new Dictionary<int, Dish>();
            var orders = new List<ClientOrder>();
            if (TempData["Orders"] != null)
            {
                var orderTEMP = (string)TempData["Orders"];
                orders = ((JArray)JsonConvert.DeserializeObject(orderTEMP)).ToObject<List<ClientOrder>>();

                orders.ForEach(co => {
                    _orderRepo.AddOrder(co);
                    if (!dishesPresent.ContainsKey(co.DishId))
                    {
                        dishesPresent.Add(co.DishId, _mealRepo.GetDish(co.DishId));
                    }
                });

                var clientId = orders.First().ClientId;
                var orderDate = orders.First().Date;
                int ordersThisMonth = _orderRepo.GetOrdersForClientForMonth(clientId, orderDate.Month, orderDate.Year).Count();
                ViewBag.ordersThisMonth = ordersThisMonth;
            }

            var days = Enum.GetValues(typeof(DayOfWeek));
            var ordersByDay = new Dictionary<DayOfWeek, IEnumerable<ClientOrder>>();

            foreach (DayOfWeek day in days)
            {
                ordersByDay.Add(day, orders.Where(co => co.Date.DayOfWeek.Equals(day)));
            }

            ViewBag.Orders = orders;
            ViewBag.OrderedDishes = dishesPresent;
            ViewBag.WeekNumber = id.ToString();

            return View(ordersByDay);
        }

        public IActionResult Orders()
        {
            var clientId = Startup.UserManager.FindByEmailAsync(User.Identity.Name).Result.Id;
            var orders = _orderRepo.GetOrdersForClient(clientId);
            var dishesById = new Dictionary<int, Dish>();
            var weeksOrdered = new Dictionary<int, Dictionary<DayOfWeek, IEnumerable<ClientOrder>>>();
            orders.ToList().ForEach(co =>
            {
                if (!weeksOrdered.ContainsKey(co.Date.Week()))
                {
                    weeksOrdered.Add(co.Date.Week(), new Dictionary<DayOfWeek, IEnumerable<ClientOrder>>());
                }
                if (!dishesById.ContainsKey(co.DishId))
                {
                    var dish = _mealRepo.GetDish(co.DishId);
                    dishesById.Add(co.DishId, dish);
                }

                // By this point we can safely assume the parent dictionary has been created, however we do not yet know if the list of orders is present
                if (weeksOrdered.GetValueOrDefault(co.Date.Week()).ContainsKey(co.Date.DayOfWeek))
                {
                    ((List<ClientOrder>)weeksOrdered.GetValueOrDefault(co.Date.Week()).GetValueOrDefault(co.Date.DayOfWeek)).Add(co);
                }
                else
                {
                    weeksOrdered.GetValueOrDefault(co.Date.Week()).Add(co.Date.DayOfWeek, new List<ClientOrder>() { co });
                }
            });

            if (orders.Count() > 0)
            {
                var orderDate = orders.First().Date;
                int ordersThisMonth = _orderRepo.GetOrdersForClientForMonth(clientId, orderDate.Month, orderDate.Year).Count();
                ViewBag.ordersThisMonth = ordersThisMonth;
            }
            ViewBag.WeeksOrdered = weeksOrdered;
            ViewBag.OrderedDishes = dishesById;
            return View(orders);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult LogOff()
        {
            Startup.SignInManager.SignOutAsync();
            return RedirectToAction("Index", "Public");
        }
    }
}
