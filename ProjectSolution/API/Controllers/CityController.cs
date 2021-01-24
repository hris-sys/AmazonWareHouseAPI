using AmazonWareHouse.Business.Models.Cities;
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
    public class CityController : Controller
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _cityService.GetAll();
            return Ok(result);
        }

        [HttpGet("{cityId}")]
        public IActionResult Get(string cityId)
        {
            var result = _cityService.GetById(cityId);
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = UserRoleConstants.Admin)]
        public async Task<IActionResult> Post(CreateCityModel model)
        {
            if (!(_cityService.GetAll().FirstOrDefault(u => u.Name == model.Name) is null))
            {
                return BadRequest("City already exists!");
            }
            else
            {
                await _cityService.CreateAsync(model);
                return Ok();
            }

        }

        [HttpDelete("{cityId}")]
        [Authorize(Roles = UserRoleConstants.Admin)]
        public IActionResult Delete(string cityId)
        {
            if (_cityService.GetAll().FirstOrDefault(u => u.Name == cityId && u.IsDeleted == true) is not null)
            {
                return BadRequest("City has already been deleted!");
            }
            else
            {
                _cityService.RemoveById(cityId);
                return Ok();
            }

        }
    }
}
