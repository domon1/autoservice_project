using BusinessLayer;
using course_test.Models;
using DataLayer.Entityes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace course_test.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private DataManager _datamanager;

        public HomeController(ILogger<HomeController> logger, DataManager datanamager)
        {
            _logger = logger;
            _datamanager = datanamager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Services()
        {
            return View();
        }

        public IActionResult Staffs()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegUserModel model)
        {
            if (ModelState.IsValid)
            {
                User user = _datamanager.User.GetAll().FirstOrDefault(x => x.Email == model.RegisterModel.Email);
                if (user == null)
                {
                    user = new User { Email = model.RegisterModel.Email, Password = model.RegisterModel.Password };
                    user.RoleId = 1;

                    _datamanager.User.Create(user);
                    _datamanager.User.Save();

                    model.Customer.UserId = user.UserId;
                    _datamanager.Customer.Create(model.Customer);
                    _datamanager.Customer.Save();

                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = _datamanager.User.Login(model.Email, model.Password);
                int custID = _datamanager.User.GetCustomerId(user);
                if (user != null && user.RoleId == 1)
                {
                    //await Authenticate(user); // аутентификация
                    return RedirectToAction("Index", "Client", new { id = custID });
                } else if (user.RoleId == 2)
                {
                    return RedirectToAction("Index", "Manager", new { id = custID });

                } else if (user.RoleId == 3)
                {
                    return RedirectToAction("Index", "Master", new { id = custID });

                } else if (user.RoleId == 2)
                {
                    return RedirectToAction("Index", "Stuff", new { id = custID });

                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }
    }
}
