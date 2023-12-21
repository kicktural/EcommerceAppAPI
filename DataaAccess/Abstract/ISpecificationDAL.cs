using Core.DataAccess.EntityFremawork;
using Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataaAccess.Abstract
{
    public interface ISpecificationDAL : IRepostoryBase<Specification>
    {
        void AddSpecifcation(int productId, List<Specification> specifications);
    }
}
