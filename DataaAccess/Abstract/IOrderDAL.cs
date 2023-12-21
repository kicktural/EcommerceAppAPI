using Core.DataAccess.EntityFremawork;
using Entities.Concreate;
using Entities.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataaAccess.Abstract
{
    public interface IOrderDAL : IRepostoryBase<Order>
    {
        void AddOrder(int userId, List<Order> orders);
        UserOrderDTO GetUserOrders(int userId);
    }
}
