using AmazonWareHouse.Business.Models.Categories;
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
    public class CategoryController : Controller
    {
        readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _categoryService.GetAll();

            return Ok(result);
        }

        [HttpGet("{categoryId}")]
        public IActionResult Get(string categoryId)
        {
            var result = _categoryService.GetById(categoryId);

            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = UserRoleConstants.Admin)]
        public async Task<IActionResult> Post(CreateCategoryModel model)
        {
            if (!(_categoryService.GetAll().FirstOrDefault(u => u.Name == model.Name && u.IsDeleted == false) is null))
            {
                return BadRequest("Item already exists!");
            }
            else
            {
                await _categoryService.CreateAsync(model);
                return Ok();
            }
        }
    }
}
