using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Models
{
    //MovieStorage class is simply a list of NewMovies objects, it includes a property (which is the movie list), as well as a method to dynamically create the movies and a method to add a movie to the list
    public class MovieStorage
    {
        private static List<NewMovies> movies = new List<NewMovies>();

        public static IEnumerable<NewMovies> Movies => movies;

        public static void addMovie(NewMovies movie)
        {
            movies.Add(movie);
        }
    }
}
