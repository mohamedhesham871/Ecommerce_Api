using Domain.Contract;
using Domain.Models;
using Persistence.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class UnitOfWork(StoreDbContext _storeDbContext) : IUnitOfwork
    {
        private readonly Dictionary<string, object> _repositories = [];

        public IGenricRepo<TEntity, Tkey> GetRepository<TEntity, Tkey>() where TEntity : BaseEntity<Tkey>
        {
            //return new GenericRepo<TEntity, Tkey>(_storeDbContext);
            //this Way UP we make Object Every Time So To Avoid this Make Dictionry

            if(_repositories.ContainsKey(typeof(TEntity).Name))
            {             // Casting Object 
                return (IGenricRepo<TEntity, Tkey>)_repositories[typeof(TEntity).Name];
            }
            else
            {     // Create New Object and Add to Dictionry
                var repo = new GenericRepo<TEntity, Tkey>(_storeDbContext);
                _repositories.Add(typeof(TEntity).Name, repo);
                return repo;
            }
        }

       
    

     //make Every thing Genric Class 
   
     

        public Task<int> SaveChanges()
        {
            return _storeDbContext.SaveChangesAsync();
        }


           
        

    }

}
