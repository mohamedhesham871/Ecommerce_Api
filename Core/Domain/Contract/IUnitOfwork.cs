using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contract
{
    public  interface IUnitOfwork
    {
        public Task<int> SaveChanges();

        public IGenricRepo<TEntity, Tkey> GetRepository<TEntity,Tkey>() where TEntity : BaseEntity<Tkey>;
      

    }
}
