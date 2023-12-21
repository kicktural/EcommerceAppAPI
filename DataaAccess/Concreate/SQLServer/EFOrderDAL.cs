using Core.DataAccess;
using DataaAccess.Abstract;
using Entities.Concreate;
using Entities.DTOs.OrderDTOs;
using Entities.DTOs.UserDTOs;
using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataaAccess.Concreate.SQLServer
{
    public class EFOrderDAL : EFRepositoryBase<Order, AppDBContext>, IOrderDAL
    {
        public void AddOrder(int userId, List<Order> orders)
        {
            using var context = new AppDBContext();
            List<Order> result = orders.Select(x =>
            {
                x.UserId = userId;
                x.OrderNumber = Guid.NewGuid().ToString().Substring(1, 10);
                x.OrderStatus = OrderStatus.OnPending;
                x.CreateDate = DateTime.Now;
                return x;
            }).ToList();

            context.Orders.AddRange(result);
            context.SaveChanges();
        }

        public UserOrderDTO GetUserOrders(int userId)
        {
            using var context = new AppDBContext();
            var result = context.AppUser
                .Where(x => x.Id == userId)
                .Select(x => new UserOrderDTO
                {
                    Email = x.Email,
                    FirstName = x.Firstname,
                    LastName = x.Lastname,
                    orderUserDTOs = x.Orders.Select(z => new OrderUserDTO
                    {
                        ProductName = z.Product.ProductName,
                        Price = z.ProductPrice,
                        Quantity = z.ProductQuantity,
                        DeliveryAddress = z.DeliveryAddress
                    }).ToList()
                }).FirstOrDefault();

            return result;
        }
    }
}
