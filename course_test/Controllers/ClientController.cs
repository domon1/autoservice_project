using BusinessLayer;
using course_test.Models;
using DataLayer.Entityes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace course_test.Controllers
{
    public class ClientController : Controller
    {
        private DataManager _dataManager;

        public ClientController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpGet]
        public IActionResult Index(int id)
        {
            Customer customer = _dataManager.Customer.GetById(id);
            return View(customer);
        }

        [HttpGet]
        public IActionResult Garage(int id)
        {
            ViewBag.custId = id; 
            return View(_dataManager.Cars.GetAllById(id));
        }



        [HttpGet]
        public IActionResult ServiceHistory(int id)
        {
            return View(_dataManager.Order.GetAllFinishedById(id));
        }

        [HttpGet]
        public IActionResult Records(int id)
        {
            ViewBag.custId = id;
            return View(_dataManager.Order.GetAllNotFinishedById(id));
        }
        
        [HttpGet]
        public IActionResult InputDate(int id){
            ViewBag.Id = id;
            return View();
        }

        [HttpPost]
        public IActionResult InputDate(string date, int id)
        {
            return RedirectToAction("RecordOnService", new { someDate = date, clientId = id});
        }

        [HttpGet]
        public IActionResult RecordOnService(string someDate, int clientId)
        {
            ViewBag.Date = someDate;
            var orderCreate = new CreateOrderModel
            {
                CarServices = _dataManager.CarService.GetAll(),
                TimeOrders = _dataManager.TimeOrder.GetTimeByDate(someDate),
                Cars = _dataManager.Cars.GetAllById(clientId)
            };

            if (orderCreate.TimeOrders == null)
            {
                return RedirectToAction("NullDateView");
            }
            else
            {
                return View(orderCreate);
            }
        }

        [HttpPost]
        public IActionResult RecordOnService(CreateOrderModel orderCreate)
        {
            orderCreate.Order.StaffId = 1;
            int custId = _dataManager.Order.GetClientId(orderCreate.Order);
            _dataManager.Order.Create(orderCreate.Order);
            _dataManager.Order.Save();
            return RedirectToAction("Index", "Client", new { id = custId});
        }
    }
}
