using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entityes
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        public string State { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public int TotalPrice { get; set; }

        public int CarId { get; set; } // foreign key Car table
        public Car Car { get; set; } // navigation property

        public int CarServiceId { get; set; } // foreign key CarService table
        public CarService CarService { get; set; } // navigation property

        public int StaffId { get; set; } // foreign key Staff table
        public Staff Staff { get; set; } // navigation property
    }
}
