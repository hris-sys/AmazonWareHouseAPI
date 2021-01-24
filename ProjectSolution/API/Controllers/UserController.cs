using AmazonWareHouse.Business.Models.Users;
using AmazonWareHouse.Business.Services.Interfaces;
using API.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Authorize(Roles = UserRoleConstants.Admin)]
        public IActionResult GetAll()
        {
            var result = _userService.GetAll();

            return Ok(result);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = UserRoleConstants.Admin)]
        public IActionResult Get(string id)
        {
            var result = _userService.GetById(id);

            if (result == null)
            {
                return NotFound("User with the provided id does not exist!");
            }

            return Ok(result);
        }

        [HttpPost]
        //[Authorize(Roles = UserRoleConstants.Admin)]
        public IActionResult Post(CreateUserModel model)
        {
            if (_userService.DoesEmailExist(model.Email))
            {
                return BadRequest("Email already exists!");
            }

            _userService.Insert(model);

            return Ok();
        }

        [HttpPut]
        [Authorize(Roles = UserRoleConstants.Admin)]
        public async Task<IActionResult> Put(EditUserModel model)
        {
            var user = _userService.GetById(model.Id);

            if (user == null)
            {
                return BadRequest("Object with the provided id does not exist!");
            }

            if (model.Email != user.Email && _userService.DoesEmailExist(model.Email))
            {
                return BadRequest("Email already exists!");
            }

            //Bug, overwrites the cityId
            await _userService.UpdateAsync(model);

            return Ok();
        }

        [HttpDelete("userId")]
        [Authorize(Roles = UserRoleConstants.Admin)]
        public IActionResult Delete(string userId)
        {
            var result = _userService.GetById(userId);

            if (result == null)
            {
                return BadRequest("Object with the provided id does not exist!");
            }

            _userService.SetDeleted(userId);

            return Ok();
        }

        [HttpGet("/order/{userId}")]
        [Authorize]
        public IActionResult GetUserOrders(string userId)
        {
            var user = _userService.GetUserOrders(userId);

            if (user == null)
            {
                return NotFound("User not found");
            }

            return Ok(user);
        }

        [HttpGet("city/{cityId}")]
        [Authorize]
        public IActionResult GetUsersFromCity(string cityId)
        {
            var cities = _userService.GetAllUsersFromCity(cityId);

            if (cities == null)
            {
                return NotFound("There are no users in this city!");
            }

            return Ok(cities);
        }


    }
}
