using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieDB.Models;

namespace MovieDB.Data
{
    public class MovieDBContext : DbContext
    {
        public MovieDBContext(DbContextOptions<MovieDBContext> options) : base(options)
        {

        }
        public virtual DbSet<Movie> Movies{ get; set; }
        public virtual DbSet<Rental> Rentals { get; set; }
    }
}
