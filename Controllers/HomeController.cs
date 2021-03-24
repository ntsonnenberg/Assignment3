using Assignment3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MoviesDbContext Context { get; set; }

        public HomeController(ILogger<HomeController> logger, MoviesDbContext con)
        {
            _logger = logger;
            Context = con;
        }

        //shows the index page view
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        //User is routed to Index page when they remove a movie from the movies DBset
        [HttpPost]
        public IActionResult Index(int movieId)
        {
            NewMovies m = Context.Movies.Single(movie => movie.MovieId == movieId);

            Context.Movies.Remove(m);
            Context.SaveChanges();

            return View();
        }

        //shows the MyPodcasts page view
        public IActionResult MyPodcasts()
        {
            return View();
        }

        //shows the Movies page view with the form if a get is called
        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();
        }

        //shows the Movies page view with the form is a post is called
        //when the form is submited, it takes the NewMovies object that gets created and adds it to the MovieList
        [HttpPost]
        public IActionResult AddMovie(NewMovies m)
        {
            if(ModelState.IsValid)
            {
                Context.Movies.Add(m);
                Context.SaveChanges();
                return Redirect("MovieList");
            }
            return View(m);
        }

        //User gets routed to the editMovie view when they click the button to edit a specific movie
        [HttpGet]
        public IActionResult EditMovie(int mID)
        {
            NewMovies movieEdit = Context.Movies.Single(movie => movie.MovieId == mID);
            return View(movieEdit);
        }

        //user gets routed to the MovieList view when the submit an edited movie, that movie gets updated and displayed in the MovieList view
        [HttpPost]
        public IActionResult EditMovie(NewMovies m)
        {
            if(ModelState.IsValid)
            {
                Context.Movies.Update(m);
                Context.SaveChanges();
                return Redirect("MovieList");
            }

            return View(m);
        }

        //shows the MovieList page view and passes in the movies
        public IActionResult MovieList()
        {
            return View(Context.Movies.Where(movie => movie.Title != "Independence Day"));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
