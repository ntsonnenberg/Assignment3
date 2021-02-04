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

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //shows the index page view
        public IActionResult Index()
        {
            return View();
        }

        //shows the MyPodcasts page view
        public IActionResult MyPodcasts()
        {
            return View();
        }

        //shows the Movies page view with the form if a get is called
        [HttpGet]
        public IActionResult Movies()
        {
            return View();
        }

        //shows the Movies page view with the form is a post is called
        //when the form is submited, it takes the NewMovies object that gets created and adds it to the MovieList
        [HttpPost]
        public IActionResult Movies(NewMovies movie)
        {
            MovieStorage.addMovie(movie);
            return View();
        }

        //shows the MovieList page view and passes in the movies
        public IActionResult MovieList()
        {
            return View(MovieStorage.Movies.Where(movie => movie.Title != "Independence Day"));
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
