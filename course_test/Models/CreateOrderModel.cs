using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace course_test.Models
{
    public class CreateOrderModel
    {
        public IEnumerable<CarService> CarServices { get; set; }
        public Order Order { get; set; }
    }
}
