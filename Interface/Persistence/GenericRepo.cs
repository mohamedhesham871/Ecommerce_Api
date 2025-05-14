using Domain.Contract;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class GenericRepo<TEntity, TKey>(StoreDbContext _storeDbContext) : IGenricRepo<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        public void Add(TEntity entity)
        {
            _storeDbContext.Set<TEntity>().Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _storeDbContext.Set<TEntity>().Remove(entity);
        }

        public void Update(TEntity entity)
        {
            _storeDbContext.Set<TEntity>().Update(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
          return await _storeDbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(TKey id)
        {
            return await _storeDbContext.Set<TEntity>().FindAsync(id);
        }

        // Making Dynamic Query
        public async Task<TEntity> GetByIdAsync(ISpecifications<TEntity> specifications)
        {                                             //input query  
            var res = await SpecificationEvaluator.crateQuery(_storeDbContext.Set<TEntity>(), specifications).FirstOrDefaultAsync();
            return res;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(ISpecifications<TEntity> specifications)
        {
            var res = await SpecificationEvaluator.crateQuery(_storeDbContext.Set<TEntity>(), specifications).ToListAsync();
            return res;
        }
    }

}
