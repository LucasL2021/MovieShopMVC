using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {

        // create an api method that shows top 30 revenue/grossing movies
        // so that my SPA, iOS and Android app show those movies in the home screen

        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        // http://localhost/api/movies/{id}
        // http://localhost/api/movies/3

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetMovie(int id) 
        {
            var movie = await _movieService.GetMovieDetails(id);
            if (movie == null) 
            {
                return NotFound($"NO MOVIE FOUND FOR {id}");
            }
            return Ok(movie);
        }


        // create the api method that shows top 30 movies , json data

        [HttpGet]
        [Route("toprevenue")]
        // Attribute based routing
        // http://localhost/api/movies/toprevenue
        // API
        public async Task<IActionResult> GetTopRevenueMovies()
        {
            var movies = await _movieService.GetTop30RevenueMovies();

            // JSON data and Http Status Code //

            if (!movies.Any())
            {
                // return 404
                return NotFound("No Movies Found");
            }

            // 200 OK
            return Ok(movies);

            // for converting C# objects to Json objects there are 2 ways
            // before .NET Core 3, we used NewtonSoft.Json library
            // Mirosoft created their own JSON Serialization library
            // System.Text.Json

        }

        [HttpGet]
        [Route("toprated")]
        // Attribute based routing
        // http://localhost/api/movies/toprated
        // API
        public async Task<IActionResult> GetTopRatedMovies()
        {
            var movies = await _movieService.GetTop30RatedMovies();

            // JSON data and Http Status Code //

            if (!movies.Any())
            {
                // return 404
                return NotFound("No Movies Found");
            }

            // 200 OK
            return Ok(movies);

            // for converting C# objects to Json objects there are 2 ways
            // before .NET Core 3, we used NewtonSoft.Json library
            // Mirosoft created their own JSON Serialization library
            // System.Text.Json

        }

        [HttpGet]
        [Route("genre/{genreId:int}")]
        // Attribute based routing
        // http://localhost/api/movies/genre/{genreId}
        // API
        public async Task<IActionResult> GetMoviesByGenreId(int genreId)
        {
            var movies = await _movieService.GetMoviesByGenreId(genreId);

            // JSON data and Http Status Code //

            if (!movies.Any())
            {
                // return 404
                return NotFound("No Movies Found");
            }

            // 200 OK
            return Ok(movies);

            // for converting C# objects to Json objects there are 2 ways
            // before .NET Core 3, we used NewtonSoft.Json library
            // Mirosoft created their own JSON Serialization library
            // System.Text.Json

        }

        [HttpGet]
        [Route("{id}/reviews")]
        // Attribute based routing
        // http://localhost/api/movies/{id}/reviews
        // API
        public async Task<IActionResult> GetMovieReviews(int id)
        {
            var movies = await _movieService.GetMovieReviews(id);

            // JSON data and Http Status Code //

            if (!movies.Any())
            {
                // return 404
                return NotFound("No Movies Found");
            }

            // 200 OK
            return Ok(movies);

            // for converting C# objects to Json objects there are 2 ways
            // before .NET Core 3, we used NewtonSoft.Json library
            // Mirosoft created their own JSON Serialization library
            // System.Text.Json

        }
    }
}
