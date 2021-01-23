using AmazonWareHouse.Business.Models.Users;
using AmazonWareHouse.Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var token = await _authService.Authenticate(model);

            if (token == null)
            {
                return BadRequest("Invalid email or password");
            }

            return Ok(token);
        }
    }

}
