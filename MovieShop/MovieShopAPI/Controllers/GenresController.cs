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
    public class GenresController : ControllerBase
    {
        private readonly IUserService _userService;

        public GenresController(IUserService userService)
        {
            _userService = userService;
        }
        // http://localhost/api/Genres

        [HttpGet]
        [Route("Genres")]
        public async Task<IActionResult> GetGenres()
        {
            var genres = await _userService.GetGenres();
            if (genres == null)
            {
                return NotFound($"NO GENRES FOUND");
            }
            return Ok(genres);
        }
    }
}
