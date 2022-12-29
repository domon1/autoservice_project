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
            return RedirectToAction("ShowRecords", new { someDate = date });
        }

        [HttpGet]
        public IActionResult ShowRecords(string someDate)
        {
            var showOrder = _datamanager.Order.GetAllNotFinishedByDate(someDate);
            if (showOrder != null)
            {
                return View(showOrder);
            }
            return View();
        }

        [HttpGet]
        public IActionResult AddStaff(int id)
        {
            var someOrder = _datamanager.Order.GetById(id);
            var addStaff = new AddStaffModel(_datamanager, someOrder);
            return View(addStaff);
        }

        [HttpPost]
        public IActionResult AddStaff(AddStaffModel addStaff)
        {
            _datamanager.Order.Update(addStaff.Order);
            _datamanager.Order.Save();
            return RedirectToAction("Index", "Staff", new { id = 5});
        }

        [HttpGet]
        public IActionResult ShowUncheckedRecords()
        {
            return View(_datamanager.Order.GetAllCheck());
        }

        [HttpGet]
        public IActionResult UncheckedRecords(int id)
        {
            var someOrder = _datamanager.Order.GetById(id);
            var addStaff = new UncheckedOrderModel(_datamanager, someOrder);
            return View(addStaff);
        }

        [HttpPost]
        public IActionResult UncheckedRecords(Order order)
        {
            _datamanager.Order.Update(order);
            _datamanager.Order.Save();
            return RedirectToAction("Index", "Staff", new { id = 5 });
        }



        [HttpGet]
        public IActionResult InputDateStaff(int id)
        {
            ViewBag.staffId = id;
            return View();
        }

        [HttpPost]
        public IActionResult InputDateStaff(string date, int id)
        {
            return RedirectToAction("ShowRecordsStaff", new { someDate = date, staffId = id });
        }

        [HttpGet]
        public IActionResult ShowRecordsStaff(string someDate, int staffId)
        {
            ViewBag.id = staffId;
            var showOrder = _datamanager.Order.GetAllWorkingByDateAndStaff(someDate, staffId);
            if (showOrder != null)
            {
                return View(showOrder);
            }
            return View();
        }

        [HttpGet]
        public IActionResult SendOnCheck(int orderId, int staffId)
        {
            Order order = _datamanager.Order.GetById(orderId);
            order.State = "check";
            _datamanager.Order.Update(order);
            _datamanager.Order.Save();
            return RedirectToAction("Index", "Staff", new { id = staffId });
        }
    }
}
