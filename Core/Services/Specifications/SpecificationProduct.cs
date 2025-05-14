using Domain.Contract;
using Domain.Models;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Specifications
{
    public class SpecificationProduct<T> : ISpecifications<T> where T :class
    {
        public Expression<Func<T, bool>>? Criteria { get; set; }

        public List<Expression<Func<T, object>>> IncludesExpression { get; set; } = new List<Expression<Func<T, object>>>();

        //make Contructor protected
         public SpecificationProduct(Expression<Func<T, bool>>? criteria)
        {
            // make Creitria nullable
            Criteria = criteria;
        }
        // Create Function To Add Include Expression
        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            IncludesExpression.Add(includeExpression);
        }
    }

}
