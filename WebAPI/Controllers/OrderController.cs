using Business.Abstract;
using Core.Utilities.Results.Concreate.SuccessResults;
using Entities.DTOs.OrderDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.IdentityModel.Tokens.Jwt;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("[action]")]
        public IActionResult OrderCreate([FromBody]List<OrderAddDTO> orderCreateDTO)
        {
            var _bearer_token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(_bearer_token);
            var userId = jwtSecurityToken.Claims.FirstOrDefault(x => x.Type == "nameid").Value;
            var user = Convert.ToInt32(userId);        

           var result = _orderService.CreateOrder(user, orderCreateDTO);
            if (result.Success) return Ok(result);
            {
                return BadRequest(result);
            }
           
        }

        [HttpGet("[action]")]
        public IActionResult GetUserOrder(int userId)
        {
            //var _bearer_token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            //var handler = new JwtSecurityTokenHandler();
            //var jwtSecurityToken = handler.ReadJwtToken(_bearer_token);
            //var userId = jwtSecurityToken.Claims.FirstOrDefault(x => x.Type == "nameid").Value;
            //var user = Convert.ToInt32(userId);

            var result = _orderService.GetUserOrder(userId: userId);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

    }
}
