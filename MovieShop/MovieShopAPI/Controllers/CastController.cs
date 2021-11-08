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
    public class CastController : ControllerBase
    {
        private readonly IUserService _userService;

        public CastController(IUserService userService)
        {
            _userService = userService;
        }
        // http://localhost/api/Cast/{id}

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetCastById(int id)
        {
            var cast = await _userService.GetCastById(id);
            if (cast == null)
            {
                return NotFound($"NO CAST FOUND FOR {id}");
            }
            return Ok(cast);
        }
    }
}
