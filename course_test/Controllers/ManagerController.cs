using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using DataLayer.Entityes;
using course_test.Models;

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
        public IActionResult Index(int id)
        {
            Staff staff = _dataManager.Staff.GetById(id);
            return View(staff);
        }

        [HttpGet]
        public IActionResult Services() => View(_dataManager.CarService.GetAll());

        [HttpGet]
        public IActionResult AddService() => View();

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
        public IActionResult Staff() => View(_dataManager.Staff.GetAll());

        [HttpGet]
        public IActionResult AddStaff() => View();

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

        [HttpGet]
        public IActionResult Spareparts() => View(_dataManager.Sparepart.GetAll());

        [HttpGet]
        public IActionResult AddSparepart() => View();


        [HttpPost]
        public IActionResult AddSparepart(Sparepart sparepart)
        {
            _dataManager.Sparepart.Create(sparepart);
            _dataManager.Sparepart.Save();
            return RedirectToAction("Spareparts");
        }

        [HttpGet]
        public IActionResult EditSparepart(int id)
        {
            Sparepart sparepart = _dataManager.Sparepart.GetById(id);
            if (sparepart != null)
            {
                return View(sparepart);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult EditSparepart(Sparepart sparepart)
        {
            _dataManager.Sparepart.Update(sparepart);
            _dataManager.Sparepart.Save();
            return RedirectToAction("Spareparts");
        }

        [HttpGet]
        [ActionName("DeleteSparepart")]
        public IActionResult ConfirmDeleteSparepart(int id)
        {
            Sparepart sparepart = _dataManager.Sparepart.GetById(id);
            if (sparepart != null)
            {
                return View(sparepart);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult DeleteSparepart(int id)
        {
            _dataManager.Sparepart.Delete(id);
            _dataManager.Sparepart.Save();
            return RedirectToAction("Spareparts");
        }

        [HttpGet]
        public IActionResult Clients() => View(_dataManager.Customer.GetAll());

        [HttpGet]
        public IActionResult AddClient() => View();

        [HttpPost]
        public IActionResult AddClient(Customer customer)
        {
            _dataManager.Customer.Create(customer);
            _dataManager.Customer.Save();
            return RedirectToAction("Clients");
        }

        [HttpGet]
        public IActionResult EditClient(int id)
        {
            Customer customer = _dataManager.Customer.GetById(id);
            if (customer != null)
            {
                return View(customer);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult EditClient(Customer customer)
        {
            _dataManager.Customer.Update(customer);
            _dataManager.Customer.Save();
            return RedirectToAction("Clients");
        }

        [HttpGet]
        [ActionName("DeleteClient")]
        public IActionResult ConfirmDeleteClient(int id)
        {
            Customer customer = _dataManager.Customer.GetById(id);
            if (customer != null)
            {
                return View(customer);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult DeleteClient(int id)
        {
            _dataManager.Customer.Delete(id);
            _dataManager.Customer.Save();
            return RedirectToAction("Clients");
        }

        [HttpGet]
        public IActionResult Profit() => View(new PartialModel(_dataManager));

        [HttpGet]
        public IActionResult DayProfit(string date) => PartialView(_dataManager.Order.GetDayProfit(date));

        [HttpGet]
        public IActionResult StaffDayProfit(string date, int staffId) => PartialView(_dataManager.Order.GetStaffDayProfit(date, staffId));

        [HttpGet]
        public IActionResult ServiceDayProfit(string date, int serviceId) => PartialView(_dataManager.Order.GetServiceDayProfit(date, serviceId));

    }
}
