using Business.Abstract;
using Entities.DTOs.CategoryAddDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        [HttpPost("[action]")]
        public IActionResult CategoryCreate([FromBody]CategoryAddDTO categoryAddDTO)
        {
            var result = _categoryService.AddCategory(categoryAddDTO);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
