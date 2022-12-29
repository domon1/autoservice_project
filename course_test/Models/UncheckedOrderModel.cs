using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace course_test.Models
{
    public class UncheckedOrderModel
    {
        public Staff Staff { get; set; }
        public CarService CarServices { get; set; }
        public TimeOrder TimeOrders { get; set; }
        public Car Cars { get; set; }
        public Order Order { get; set; }
    }
}
