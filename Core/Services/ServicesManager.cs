using AbstractionServices;
using AutoMapper;
using Domain.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public  class ServicesManager(IUnitOfwork _unitOfwork,IMapper _mapper): IServicesManager
    {
        private readonly Lazy<IProductServices> _LazyProductServices
                   = new Lazy<IProductServices>(() => new ProductServices(_unitOfwork, _mapper));
       
        public IProductServices ProductServices => _LazyProductServices.Value;
    }
 
}
