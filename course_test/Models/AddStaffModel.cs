using BusinessLayer;
using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace course_test.Models
{
    public class AddStaffModel
    {
        private DataManager _datamanager;
        public IEnumerable<Staff> Staffs { get; set; }
        public CarService CarServices { get; set; }
        public TimeOrder TimeOrders { get; set; }
        public Car Cars { get; set; }
        public Order Order { get; set; }
        

        public AddStaffModel(DataManager datamanager, Order someOrder)
        {
            _datamanager = datamanager;
            Staffs = _datamanager.Staff.GetAllStaff();
            Cars = _datamanager.Cars.GetById(someOrder.CarId);
            CarServices = _datamanager.CarService.GetById(someOrder.CarServiceId);
            TimeOrders = _datamanager.TimeOrder.GetById(someOrder.TimeOrderId);
            Order = someOrder;
        }

        public AddStaffModel()
        {

        }
    }
}
