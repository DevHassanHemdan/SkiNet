using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface _IUnitOfWork : IDisposable
    {
        _IGenericRepository<Product> ProductRepository { get; }
        _IGenericRepository<ProductBrand> ProductBrandRepository { get; }
        _IGenericRepository<ProductType> ProductTypeRepository { get; }
        Task<int> SaveAsync();
    }
}
