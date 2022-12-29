using BusinessLayer;
using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace course_test.Models
{
    public class PartialModel
    {
        private DataManager _datamanager;
        public IEnumerable<CarService> CarServices { get; set; }
        public IEnumerable<Staff> Staff { get; set; }

        public PartialModel(DataManager datamanager)
        {
            _datamanager = datamanager;
            CarServices = _datamanager.CarService.GetAll();
            Staff = _datamanager.Staff.GetAllStaff();
        }

        public PartialModel()
        {

        }
    }
}
