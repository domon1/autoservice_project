using BusinessLayer;
using course_test.Models;
using DataLayer.Entityes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace course_test.Controllers
{
    public class StaffController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private DataManager _datamanager;

        public StaffController(ILogger<HomeController> logger, DataManager datanamager)
        {
            _logger = logger;
            _datamanager = datanamager;
        }

        [HttpGet]
        public IActionResult Index(int id)
        {
            Staff staff = _datamanager.Staff.GetById(id);
            return View(staff);
        }

        [HttpGet]
        public IActionResult InputDate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult InputDate(string date)
        {
            return RedirectToAction("ShowRecords", new { someDate = date});
        }

        [HttpGet]
        public IActionResult ShowRecords(string someDate)
        {
            var showOrder = _datamanager.Order.GetAllNotFinishedByDate(someDate);

            if (showOrder != null)
            {
                return View(showOrder);
            }
            ModelState.AddModelError("", "Not records!");

            return View();
        }
    }
}
