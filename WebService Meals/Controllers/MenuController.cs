using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebService_Meals.Controllers
{
    [Authorize]
    public class MenuController : Controller
    {

        private readonly IMealServiceRepository _repo;

        public MenuController(IMealServiceRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            return View(_repo.GetAllMenus());
        }
    }
}