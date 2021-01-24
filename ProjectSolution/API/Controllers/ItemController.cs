using AmazonWareHouse.Business.Models.Items;
using AmazonWareHouse.Business.Services.Interfaces;
using API.Infrastructure;
using Data.Services.Interfaces;
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
    public class ItemController : Controller
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _itemService.GetAll();

            return Ok(result);
        }

        [HttpGet("{itemId}")]
        public IActionResult Get(string itemId)
        {
            var result = _itemService.GetByIdWithCategory(itemId);

            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = UserRoleConstants.Admin)]
        public async Task<IActionResult> Post(CreateItemModel model)
        {
            if (!(_itemService.GetAll().FirstOrDefault(u => u.Name == model.Name) is null))
            {
                return BadRequest("Item already exists!");
            }
            else
            {
                await _itemService.InsertAsync(model);
                return Ok();
            }
        }

    }
}
