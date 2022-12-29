using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entityes
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Not input name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Not input surname")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Not input patrionomic")]
        public string Patrionomic { get; set; }
        [Required(ErrorMessage = "Not input phone number")]
        [Phone]
        public string PhoneNumber { get; set; }

        public List<Car> Cars { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
