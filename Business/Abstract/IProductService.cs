using Core.Utilities.Results.Abstract;
using Entities.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        IResult AddProduct(ProductAddDTO productAddDTO);
        IResult UpdateProduct(ProductUpdateDTO productUpdateDTO);
        IResult ChangeProductStatus(int productId, bool Status);
        IResult DeleteProduct(int productId);
        IDataResult<List<ProductFilterDTO>> FilterProductsList(int categoryId, decimal minPrice, decimal maxPrice);
        IDataResult<ProductGetDTO> GetProduct(int productId);
        IDataResult<bool> CheckProductCount(List<int> productIds);
        IResult RemoveProductStockCount(List<ProductDecrementQuantityDTO> productDecrementQuantityDTOs);
    }
}
