using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDB.Models
{
    [Table("tbRentals")]
    public class Rental
    {
        [Key]
        public int RentID { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string fName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string lName { get; set; }
        [Required]
        [DisplayName("Phone Number")]
        public string PhoneNum { get; set; }
        [Required]
        [DisplayName("Movie Rented")]
        public int MovieID { get; set; }

    }
}
