using Domain.Contract;
using Domain.Models;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Services.Specifications
{
    public class BaseSpecification<T> : ISpecifications<T> where T :class
    {
        public Expression<Func<T, bool>>? Criteria { get; private set ; }

        public List<Expression<Func<T, object>>> IncludesExpression { get; private set; } = new List<Expression<Func<T, object>>>();

        public Expression<Func<T, object>>? OrderBy { get; private set; }
        public Expression<Func<T, object>>? OrderByDesc { get; private set; }

        public int Skip { get; private set; }

        public int Take { get; private set; }

        public bool IsPagingEnabled { get; private set; }


        //make Contructor protected  //Will Chain on Criteria
        public BaseSpecification(Expression<Func<T, bool>>? criteria)
        {
            // make Creitria nullable
            Criteria = criteria;
        }
        // Create Function To Add Include Expression
        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            IncludesExpression.Add(includeExpression);
        }

        //Create Function To Add OrderBy Expression
        protected void AddOrderBy(Expression<Func<T, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }
        //Create Function To Add OrderByDesc Expression
        protected void AddOrderByDesc(Expression<Func<T, object>> orderByDescExpression)
        {
            OrderByDesc = orderByDescExpression;
        }

        //Method Apply Paging
        public void Applypagination(int indexpage, int pageSize)
        {
            IsPagingEnabled = true;
            Take = pageSize;
            Skip = (indexpage-1)*pageSize;


        }
    }

}
