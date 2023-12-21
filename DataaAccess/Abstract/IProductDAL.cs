using Core.DataAccess.EntityFremawork;
using Entities.Concreate;
using Entities.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataaAccess.Abstract
{
    public interface IProductDAL : IRepostoryBase<Product>
    {
        Product GetProduct(int id);
        void RemoveProductCount(List<ProductDecrementQuantityDTO> productDecrementQuantityDTOs);
    }
}
