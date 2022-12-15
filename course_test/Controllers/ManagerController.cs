using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using DataLayer.Entityes;

namespace course_test.Controllers
{
    public class ManagerController : Controller
    {
        private DataManager _dataManager;

        public ManagerController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Services()
        {
            return View(_dataManager.CarService.GetAll());
        }

        [HttpGet]
        public IActionResult AddService()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddService(CarService carService)
        {
            _dataManager.CarService.Create(carService);
            _dataManager.CarService.Save();
            return RedirectToAction("Services");
        }

        [HttpGet]
        public IActionResult EditService(int id)
        {
            CarService carService = _dataManager.CarService.GetById(id);
            if (carService != null)
            {
                return View(carService);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult EditService(CarService carService)
        {
            _dataManager.CarService.Update(carService);
            _dataManager.CarService.Save();
            return RedirectToAction("Services");
        }

        [HttpGet]
        [ActionName("DeleteService")]
        public IActionResult ConfirmDeleteService(int id)
        {
            CarService carService = _dataManager.CarService.GetById(id);
            if (carService != null)
            {
                return View(carService);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult DeleteService(int id)
        {
            _dataManager.CarService.Delete(id);
            _dataManager.CarService.Save();
            return RedirectToAction("Services");
        }

        [HttpGet]
        public IActionResult Staff()
        {
            return View(_dataManager.Staff.GetAll());
        }

        [HttpGet]
        public IActionResult AddStaff()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddStaff(Staff staff)
        {
            _dataManager.Staff.Create(staff);
            _dataManager.Staff.Save();
            return RedirectToAction("Staff");
        }

        [HttpGet]
        public IActionResult EditStaff(int id)
        {
            Staff staff = _dataManager.Staff.GetById(id);
            if (staff != null)
            {
                return View(staff);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult EditStaff(Staff staff)
        {
            _dataManager.Staff.Update(staff);
            _dataManager.Staff.Save();
            return RedirectToAction("Staff");
        }

        [HttpGet]
        [ActionName("DeleteStaff")]
        public IActionResult ConfirmDeleteStaff(int id)
        {
            Staff staff = _dataManager.Staff.GetById(id);
            if (staff != null)
            {
                return View(staff);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult DeleteStaff(int id)
        {
            _dataManager.Staff.Delete(id);
            _dataManager.Staff.Save();
            return RedirectToAction("Staff");
        }
    }
}
