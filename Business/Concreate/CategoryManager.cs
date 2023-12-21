using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concreate.ErrorResults;
using Core.Utilities.Results.Concreate.SuccessResults;
using DataaAccess.Abstract;
using Entities.Concreate;
using Entities.DTOs.CategoryAddDTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDAL _categoryDAL;
        private readonly IMapper _mapper;
        public CategoryManager(ICategoryDAL categoryDAL, IMapper mapper)
        {
            _categoryDAL = categoryDAL;
            _mapper = mapper;
        }

        public IResult AddCategory(CategoryAddDTO categoryAddDTO)
        {
            try
            {
            var map = _mapper.Map<Category>(categoryAddDTO);
            _categoryDAL.Add(map);
            return new SuccessResult("Success Added");
            }
            catch (Exception ex)
            {

                return new ErrorResult(ex.Message);
            }
        }
    }
}
