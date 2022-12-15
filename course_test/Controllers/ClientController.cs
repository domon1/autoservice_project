﻿using BusinessLayer;
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
            id = 1;
            Customer customer = _dataManager.Customer.GetById(id);
            return View(customer);
        }

        [HttpGet]
        public IActionResult Garage(int id)
        {
            return View(_dataManager.Cars.GetAllById(id));
        }

        [HttpGet]
        public IActionResult ServiceHistory(int id)
        {
            return View(_dataManager.Order.GetAllById(id));
        }

        [HttpGet]
        public IActionResult Records(int id)
        {
            return View(_dataManager.Order.GetAllNotFinishedById(id));
        }

        [HttpGet]
        public IActionResult RecordOnService()
        {
            return View();
        }
    }
}