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
        public class EFSpecificationDAL : EFRepositoryBase<Specification, AppDBContext>, ISpecificationDAL
        {
            public void AddSpecifcation(int productId, List<Specification> specifications)
            {
            
                    using var context = new AppDBContext();

                    var result = specifications
                        .Select(x =>
                        {
                            x.ProductId = productId;
                            x.CreateDate = DateTime.Now;
                            //x.UpdateDate = DateTime.Now;
                            return x;
                        }).ToList();

                    context.Specifications.AddRange(result);
                    context.SaveChanges();            
            }
        }
    }
