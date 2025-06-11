using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contract
{
    public  interface ISpecifications<T> where T : class
    {
        Expression<Func<T, bool>>? Criteria { get;  }
        List<Expression<Func<T, object>>> IncludesExpression { get; }
        Expression<Func<T, object>>? OrderBy { get;  }
        Expression<Func<T, object>>? OrderByDesc { get; }
        int Skip { get; }
        int Take { get; }
        bool IsPagingEnabled { get; }
       

    }
}
