using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace course_test.Models
{
    public class RegUserModel
    {
        public Customer Customer { get; set; }
        public RegisterModel RegisterModel { get; set; }
    }
}
