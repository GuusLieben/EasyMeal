using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EasyMeal.Core.Domain;
using EasyMeal.Core.Domain.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Extensions = EasyMeal.Core.Domain.Extensions;

namespace Infrastructure.Meals
{
    class APIReadOnlyRepository
    {
        private const string BaseUrl = "localhost:5001/api/";

        private static async Task<string> GetResponseFor(string uri)
        {
            using (var client = new HttpClient())
            {
                using (var res = await client.GetAsync(uri))
                {
                    return await res.Content.ReadAsStringAsync();
                }
            }
        }

        public async Task<Dish> GetDish(int Id)
        {
            return (Dish) JsonConvert.DeserializeObject(await GetResponseFor(BaseUrl + "dishes/" + Id), typeof(Dish));
        }

        public async Task<IEnumerable<Dish>> GetAllDishes()
        {
            return (Dish[]) JsonConvert.DeserializeObject(await GetResponseFor(BaseUrl + "dishes/"), typeof(Dish[]));
        }

        public async Task<IEnumerable<Dish>> GetAllDishesForMeal(Meal meal)
        {
            return await GetAllDishesForMeal(meal.Id);
        }

        public async Task<IEnumerable<Dish>> GetAllDishesForMeal(int mealId)
        {
            return (Dish[])JsonConvert.DeserializeObject(await GetResponseFor(BaseUrl + "dishes?meal=" + mealId), typeof(Dish[]));
        }

        public async Task<Meal> GetMeal(int Id)
        {
            return (Meal)JsonConvert.DeserializeObject(await GetResponseFor(BaseUrl + "meals/" + Id), typeof(Meal));
        }

        public async Task<IEnumerable<Meal>> GetAllMealOptions()
        {
            return (Meal[])JsonConvert.DeserializeObject(await GetResponseFor(BaseUrl + "meals/"), typeof(Meal[]));
        }

        public async Task<IEnumerable<Meal>> GetAllMealOptionsForWeek(int week, int year)
        {
            var date = Extensions.StartOfWeek(year, week);
            return (Meal[])JsonConvert.DeserializeObject(await GetResponseFor(BaseUrl + "meals?date=" + date + "&week=true"), typeof(Meal[]));
        }

        public async Task<IEnumerable<Meal>> GetAllMealOptionsForDay(DateTime day)
        {
            return (Meal[])JsonConvert.DeserializeObject(await GetResponseFor(BaseUrl + "meals?date=" + day), typeof(Meal[]));
        }

        public Menu GetMenu(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Menu> GetAllMenus()
        {
            throw new NotImplementedException();
        }
    }
}
