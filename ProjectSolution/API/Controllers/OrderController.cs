using AmazonWareHouse.Business.Models.Order;
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
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ICityService _cityService;
        private readonly IUserService _userService;

        public OrderController(IOrderService orderService, ICityService cityService, IUserService userService)
        {
            _orderService = orderService;
            _cityService = cityService;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _orderService.GetAll();

            return Ok(result);
        }

        [HttpGet("{orderId}")]
        public IActionResult Get(string orderId)
        {
            var result = _orderService.GetById(orderId);

            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = UserRoleConstants.Admin)]
        public async Task<IActionResult> Post(CreateOrderModel model)
        {
            var cityFromDb = this._cityService.GetByIdAndReturnCityObject(model.City.CityId);
            var userFromDb = this._userService.GetUserAndReturnUserModel(model.User.UserId);

            if (cityFromDb is null || userFromDb is null)
            {
                return BadRequest("The provided city doesn't exist!");
            }

            await this._orderService.CreateAsync(userFromDb, cityFromDb.Id, model.Remarks);

            return Ok();
        }
    }
}
