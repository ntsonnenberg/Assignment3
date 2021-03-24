using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Models
{
    //This is the DB context class for movies, it has a dbset of movies
    public class MoviesDbContext: DbContext
    {
        public MoviesDbContext(DbContextOptions<MoviesDbContext> options): base(options)
        {

        }

        public DbSet<NewMovies> Movies { get; set; }
    }
}
