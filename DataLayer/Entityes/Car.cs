using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entityes
{
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CarId { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public string LicencePlate { get; set; }
        public int YearOfIssue { get; set; }

        public int CustomerId { get; set; }  // foreign key Customer table
        public Customer Customer { get; set; }  // navigation property

        public List<Order> Orders { get; set; } // navigation property

    }
}
