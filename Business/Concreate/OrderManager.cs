using AutoMapper;
using Business.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concreate.ErrorResults;
using Core.Utilities.Results.Concreate.SuccessResults;
using DataaAccess.Abstract;
using Entities.Concreate;
using Entities.DTOs.OrderDTOs;
using Entities.DTOs.ProductDTOs;
using Entities.DTOs.UserDTOs;

namespace Business.Concreate
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderDAL _orderDAL;
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        private readonly IUserService _userService;
        public OrderManager(IOrderDAL orderDAL, IMapper mapper, IProductService productService, IUserService userService)
        {
            _orderDAL = orderDAL;
            _mapper = mapper;
            _productService = productService;
            _userService = userService;
        }

        public IResult CreateOrder(int userId, List<OrderAddDTO> orderAddDTOs)
        {
            var productIds = orderAddDTOs.Select(x => x.ProductId).ToList();
            var quantities = orderAddDTOs.Select(x => x.Quantity).ToList();
            var result = BusinessRoles.CheckLogic(CheckProductStockCount(productIds));

            if (!result.Success)
            {
                return new ErrorResult(message: "Error Result");
            }

            var map = _mapper.Map<List<Order>>(orderAddDTOs);
           
            _orderDAL.AddOrder(userId, map);

            var products = orderAddDTOs.Select(x => new ProductDecrementQuantityDTO
            {
                ProductId = x.ProductId,
                Quantity = x.Quantity
            }).ToList();

            _productService.RemoveProductStockCount(products);
            return new SuccessResult(message: "Success Result");
        }

        public IDataResult<UserOrderDTO> GetUserOrder(int userId)
        {

            //var test = _userService.GetUser(userId);
            //var map = _mapper.Map<UserOrderDTO>(test);

            var result = _orderDAL.GetUserOrders(userId);
            return new SuccessDataResult<UserOrderDTO>(result);
        }

        private IResult CheckProductStockCount(List<int> producIds)
        {
            var result = _productService.CheckProductCount(producIds);
            if (result.Success)
                return new SuccessResult("Completed successfully");

            return new ErrorResult("You have a mistake");
        }
    }
}
