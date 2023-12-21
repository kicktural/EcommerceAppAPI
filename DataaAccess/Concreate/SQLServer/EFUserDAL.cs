using Core.DataAccess;
using DataaAccess.Abstract;
using Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataaAccess.Concreate.SQLServer
{
    public class EFUserDAL : EFRepositoryBase<User, AppDBContext>, IUserDAL
    {
        public User GetUserOrders(int userId)
        {
            using var context = new AppDBContext();

            var user = context.AppUser
                .Include(x => x.Orders)
                .FirstOrDefault(x => x.Id == userId);

            return user;
        }
    }
}
