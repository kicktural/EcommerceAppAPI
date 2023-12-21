using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concreate.ErrorResults;
using Core.Utilities.Results.Concreate.SuccessResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business
{
    public class BusinessRoles
    {
        public static IResult CheckLogic(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                    return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
