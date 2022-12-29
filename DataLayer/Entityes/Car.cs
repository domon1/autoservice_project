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
        [Required]
        public string Mark { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        [StringLength(9, MinimumLength = 8, ErrorMessage = "Licence plate X000XXYY(Y)")]
        public string LicencePlate { get; set; }
        [Required]
        [Range(1940, 2030, ErrorMessage = "Invalid year!")]
        public int YearOfIssue { get; set; }

        public int CustomerId { get; set; }  // foreign key Customer table
        public Customer Customer { get; set; }  // navigation property

        public List<Order> Orders { get; set; } // navigation property

    }
}
