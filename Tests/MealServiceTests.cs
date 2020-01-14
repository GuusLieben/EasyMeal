using System;
using System.Collections.Generic;
using System.Linq;
using EasyMeal.Core.Domain;
using EasyMeal.Infrastructure.Meals;
using EasyMeal.Web.Meals.Controllers;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Tests
{
    public class MealServiceTests
    {

        public MealDbContext GetContext()
        {
            var options = new DbContextOptionsBuilder<MealDbContext>()
                .UseInMemoryDatabase(databaseName: "meals_db")
                .Options;
            var context = new MealDbContext(options);
            // Make sure we clear the database before each run
            context.Database.EnsureDeleted();
            return context;
        }

        public Dish GetTestDish()
        {
            return new Dish("Test dish", "Testing dishes", DishSize.Small, 35.00, DishType.Main);
        }

        public Meal GetTestMeal()
        {
            return new Meal() {DateValid = DateTime.Now};
        }

        public Dish[] GetTestDishes()
        {
            var dish1 = GetTestDish();
            dish1.DishType = DishType.Starter;

            var dish2 = GetTestDish();

            var dish3 = GetTestDish();
            dish1.DishType = DishType.Dessert;

            return new[] {dish1, dish2, dish3};
        }

        [Fact]
        public void CreateDishShouldAddDish()
        {
            using (var context = GetContext())
            {
                var repo = new EFMealServiceRepository(context);
                repo.CreateDish(GetTestDish());
                context.SaveChanges();
                Assert.Equal(1, context.Dishes.Count());
                Assert.Equal(GetTestDish().Name, context.Dishes.Single().Name);
            }
        }

        [Fact]
        public void CreateDishShouldCreateEqualDish()
        {
            using (var context = GetContext())
            {
                var repo = new EFMealServiceRepository(context);
                repo.CreateDish(GetTestDish());
                context.SaveChanges();
                Assert.Equal(GetTestDish().Name, context.Dishes.Single().Name);
            }
        }

        [Fact]
        public void TestGetDish()
        {
            var dish = GetTestDish();
            using (var context = GetContext())
            {
                var repo = new EFMealServiceRepository(context);
                repo.CreateDish(dish);
                context.SaveChanges();
                Assert.Equal(dish.Name, repo.GetDish(dish.Id).Name);
            }
        }

        [Fact]
        public void CreateMealShouldAddMeal()
        {
            using (var context = GetContext())
            {
                var repo = new EFMealServiceRepository(context);
                var result = repo.CreateMeal(GetTestMeal(), GetTestDishes());
                context.SaveChanges();
                Assert.Equal(1, context.Meals.Count());
            }
        }

        [Fact]
        public void CreateMealShouldReturnPositive()
        {
            using (var context = GetContext())
            {
                var repo = new EFMealServiceRepository(context);
                var result = repo.CreateMeal(GetTestMeal(), GetTestDishes());
                context.SaveChanges();
                Assert.True(result);
            }
        }

        [Fact]
        public void TestGetMeal()
        {
            using (var context = GetContext())
            {
                var repo = new EFMealServiceRepository(context);
                repo.CreateMeal(GetTestMeal(), GetTestDishes());
                context.SaveChanges();
                Assert.NotEmpty(repo.GetAllMealOptions());
            }
        }

        [Fact]
        public void TestDietRestrictionWarnings()
        {
            using (var context = GetContext())
            {
                var repo = new EFMealServiceRepository(context);
                var controller = new MealController(repo);

                controller.Index();
                var bag = controller.ViewBag;

                Assert.False(bag.SaltWarning);
                Assert.False(bag.SugarWarning);
                Assert.False(bag.GlutenWarning);
            }
        }

        [Fact]
        public void TestMenuOrderRulesAcceptsCorrectValues()
        {
            const int amountOfOrders = 4;
            const bool weekMatchesCurrent = true;

            var valid = Extensions.OrderDishesRules(amountOfOrders, weekMatchesCurrent);
            Assert.True(valid);
        }

        [Fact]
        public void TestMenuOrderRulesRejectsInvalidValues()
        {
            const int amountOfOrders = 2;
            const bool weekMatchesCurrent = true;

            var valid = Extensions.OrderDishesRules(amountOfOrders, weekMatchesCurrent);
            Assert.False(valid);
        }

        [Fact]
        public void TestTotalOrderCost()
        {
            var dish1 = new Dish() { Name = "Testable", Price = 15.00, Id = 1 };
            var order1 = new ClientOrder() {ClientId = "Testable", DishId = 1, Id = 1, Size = DishSize.Large};

            var dish2 = new Dish() { Name = "Testable", Price = 35.00, Id = 2 };
            var order2 = new ClientOrder() { ClientId = "Testable", DishId = 2, Id = 2, Size = DishSize.Small };

            var dict = new Dictionary<int, Dish>() {{1, dish1}, {2, dish2}};
            var orders = new List<ClientOrder>() {order1, order2};

            var totalPrice = Extensions.TotalPrice(orders, dict);
            Assert.Equal(46.00, totalPrice);

        }

        [Fact]
        public void TestDiscountRules()
        {
            const double price = 100.00;
            const double shipment = 5.00;
            const double dishDiscount = 7.50;
            const double birthdayDiscount = 10.00;

            var totalPrice = Extensions.CalculateTotalDiscount(price, shipment, dishDiscount, birthdayDiscount);

            Assert.Equal(87.50, totalPrice);
        }
    }
}
