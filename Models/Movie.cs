using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDB.Models
{
    public class Movie
    {
        [Key]
        public int MovieID { get; set; }
        [Required]
        [DisplayName("Title")]
        public string Title { get; set; }
        [Required]
        [DisplayName("Date Of Release")]
        public DateTime DateOfRelease { get; set; }
        [DisplayName("Genre")]
        public string? Genre { get; set; }
        [Required]
        [DisplayName("Price of production $(USD)")]
        public decimal Price { get; set; }
    }
}
