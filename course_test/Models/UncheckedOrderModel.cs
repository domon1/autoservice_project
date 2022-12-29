using BusinessLayer;
using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace course_test.Models
{
    public class UncheckedOrderModel
    {
        private DataManager _datamanager;
        public Staff Staff { get; set; }
        public CarService CarServices { get; set; }
        public TimeOrder TimeOrders { get; set; }
        public Car Cars { get; set; }
        public Order Order { get; set; }

        public UncheckedOrderModel(DataManager datamanager, Order someOrder)
        {
            _datamanager = datamanager;
            Staff = _datamanager.Staff.GetById(someOrder.StaffId);
            Cars = _datamanager.Cars.GetById(someOrder.CarId);
            CarServices = _datamanager.CarService.GetById(someOrder.CarServiceId);
            TimeOrders = _datamanager.TimeOrder.GetById(someOrder.TimeOrderId);
            Order = someOrder;
        }

        public UncheckedOrderModel()
        {

        }
    }
}
