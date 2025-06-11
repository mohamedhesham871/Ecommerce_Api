using Domain.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public abstract  class SpecificationEvaluator
    {
        // this is the main method for making dynamic query
        public static IQueryable<T> crateQuery<T>(IQueryable<T> inputQuery, ISpecifications<T> specifications)where T : class 
        {
            // check if the specifications has criteria
            if (specifications.Criteria is not null)
            {
                inputQuery = inputQuery.Where(specifications.Criteria);
            }
            // check if the specifications has includes

            #region include
            //.. Can Use for Loop Or Use Aggregate Function
            //if (specifications.IncludesExpression != null && specifications.IncludesExpression.Count > 0)
            //{
            //    foreach (var include in specifications.IncludesExpression)
            //    {
            //        inputQuery = inputQuery.Include(include);
            //    }
            //}
            inputQuery = specifications.IncludesExpression
                      .Aggregate(inputQuery, (current, include) => current.Include(include));


            #endregion
            // check if the specifications has order by
            if (specifications.OrderBy is not null)
            {
                inputQuery = inputQuery.OrderBy(specifications.OrderBy);
            }
            else if(specifications.OrderByDesc is not null)
            {
                inputQuery = inputQuery.OrderByDescending(specifications.OrderByDesc);
            }

            //Apply Pagination on Query
            if (specifications.IsPagingEnabled)
            {
                inputQuery = inputQuery.Skip(specifications.Skip)
                    .Take(specifications.Take);
            }
            return inputQuery;
        }
    }
}
