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
        [StringLength(12, MinimumLength = 3, ErrorMessage = "Name lenght must be 3 - 12 symbols")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Not input surname")]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "Surname lenght must be 5 - 15 symbols")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Not input patrionomic")]
        [StringLength(18, MinimumLength = 6, ErrorMessage = "Patrionomic lenght must be 6 - 18 symbols")]
        public string Patrionomic { get; set; }

        [Required(ErrorMessage = "Not input phone number")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }

        public List<Car> Cars { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
