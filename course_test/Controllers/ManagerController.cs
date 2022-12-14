using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;

namespace course_test.Controllers
{
    public class ManagerController : Controller
    {
        private DataManager _dataManager;

        public ManagerController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Services()
        {
            return View(_dataManager.CarService.GetAll());
        }
    }
}
