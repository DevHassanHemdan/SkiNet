using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Data
{
    public class _UnitOfWork : _IUnitOfWork
    {
        private readonly StoreContext _storeContext;
        public _IGenericRepository<Product> productRepository;
        public _IGenericRepository<ProductBrand> productBrandRepository;
        public _IGenericRepository<ProductType> productTypeRepository;
        public _UnitOfWork(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }
        public _IGenericRepository<Product> ProductRepository
        {
            get
            {
                if (productRepository == null)
                    productRepository = new _GenericRepository<Product>(_storeContext);
                return productRepository;
            }
        }

        public _IGenericRepository<ProductBrand> ProductBrandRepository
        {
            get
            {
                if (productBrandRepository == null)
                    productBrandRepository = new _GenericRepository<ProductBrand>(_storeContext);
                return productBrandRepository;
            }
        }

        public _IGenericRepository<ProductType> ProductTypeRepository
        {
            get
            {
                if (productTypeRepository == null)
                    productTypeRepository = new _GenericRepository<ProductType>(_storeContext);
                return productTypeRepository;
            }
        }

        public void Dispose()
        {
            try
            {
                _storeContext.Dispose();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> SaveAsync()
        {
            return await _storeContext.SaveChangesAsync();
        }
    }
}
