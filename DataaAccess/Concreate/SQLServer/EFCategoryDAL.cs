using Core.DataAccess;
using DataaAccess.Abstract;
using Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataaAccess.Concreate.SQLServer
{
    public class EFCategoryDAL : EFRepositoryBase<Category, AppDBContext>, ICategoryDAL
    {
    }
}
