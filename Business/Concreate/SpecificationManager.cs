using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concreate.ErrorResults;
using Core.Utilities.Results.Concreate.SuccessResults;
using DataaAccess.Abstract;
using Entities.Concreate;
using Entities.DTOs.SpecificationDTO;

namespace Business.Concreate
{
    public class SpecificationManager : ISpecificationService
    {
        private readonly ISpecificationDAL _specificationDAL;
        private readonly IMapper _mapper;
        public SpecificationManager(ISpecificationDAL specificationDAL, IMapper mapper)
        {
            _specificationDAL = specificationDAL;
            _mapper = mapper;
        }

        public IResult AddSpecificationProduct(int productId, List<SpecificationAddDTO> specificationAddDTOs)
        {
            try
            {
                var map = _mapper.Map<List<Specification>>(specificationAddDTOs);

                _specificationDAL.AddSpecifcation(productId, map);
                return new SuccessResult("Success");
            }
            catch (Exception ex)
            {

                return new ErrorResult(ex.Message);
            }
        }
    }
}
