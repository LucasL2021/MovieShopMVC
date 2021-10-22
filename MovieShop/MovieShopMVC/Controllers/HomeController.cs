using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieShopMVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Models;
using Infrastructure.Services;
using ApplicationCore.ServiceInterfaces;

namespace MovieShopMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMovieService _movieService;
        public HomeController(IMovieService movieService) 
        {
            _movieService = movieService;
        }

        //Routing
        //https://localhost/home/index
        //by default it's get
        [HttpGet]
        public IActionResult Index()
        {
            //Views Folder => Home => Index.cshtml
            //call movie service class to get a list of movies card models
            var movieCards = _movieService.GetTop30RevenueMovies();
            //passing data from controller to view, strongly typed models(most used)
            //other ways: ViewBag and ViewData
            ViewBag.PageTitle = "Top Revenue Movies";
            ViewData["xyz"] = "test data";
            return View(movieCards);
        }
        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult TopMovies()
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
