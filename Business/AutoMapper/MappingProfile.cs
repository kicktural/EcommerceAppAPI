using AutoMapper;
using Entities.Concreate;
using Entities.DTOs.CategoryAddDTOs;
using Entities.DTOs.OrderDTOs;
using Entities.DTOs.ProductDTOs;
using Entities.DTOs.SpecificationDTO;
using Entities.DTOs.UserDTOs;
using Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterDTO, User>();

            CreateMap<CategoryAddDTO, Category>();
            
            CreateMap<ProductAddDTO, Product>();
            CreateMap<ProductUpdateDTO, Product>();
            CreateMap<ProductChangeStatusDTO, Product>();
            CreateMap<Product, ProductFilterDTO>();
            CreateMap<Product, ProductGetDTO>();

            CreateMap<SpecificationAddDTO, Specification>();
            CreateMap<Specification, SpecificationGetListDTO>();

            CreateMap<OrderAddDTO, Order>();
            //CreateMap<Order, OrderUserDTO>();

            //CreateMap<User, UserOrderDTO>();
        } 
    }
}
