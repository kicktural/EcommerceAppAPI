using Business.Abstract;
using Entities.DTOs.ProductDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("ProductCreate")]
        public IActionResult ProductCreate(ProductAddDTO productAddDTO)
        {
            var result = _productService.AddProduct(productAddDTO);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPut("ProductUpdate")]
        public IActionResult ProductUpdate(ProductUpdateDTO productUpdateDTO)
        {
            var result = _productService.UpdateProduct(productUpdateDTO);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPatch("[action]")]
        public IActionResult ChangeStatusProduct(int Id, bool status)
        {
            var result = _productService.ChangeProductStatus(Id, status); 
            return Ok(result);
        }

        [HttpDelete("[action]")]
        public IActionResult ProductDelete(int Id)
        {
            var result = _productService.DeleteProduct(Id);
            return Ok(result);
            
        }

        [HttpGet("[action]")]
        public IActionResult GetAllProductFilter(int categoryId, decimal minPrice, decimal maxPrice)
        {
            var result = _productService.FilterProductsList(categoryId, minPrice, maxPrice);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("[action]/{productId}")]
        public IActionResult GetProductDetail(int productId)
        {
            var result = _productService.GetProduct(productId);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
