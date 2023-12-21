using Core.DataAccess.EntityFremawork;
using Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataaAccess.Abstract
{
    public interface IUserDAL : IRepostoryBase<User>
    {
        User GetUserOrders(int userId);
    }
}
